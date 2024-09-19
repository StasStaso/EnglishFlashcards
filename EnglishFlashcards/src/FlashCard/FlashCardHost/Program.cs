using Amazon.Runtime;
using Amazon.Translate;
using FlashCard.Host.Data;
using FlashCard.Host.Data.InitialData;
using FlashCard.Host.Mappings;
using FlashCard.Host.Repositories;
using FlashCard.Host.Repositories.Abstractions;
using FlashCard.Host.Services;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Services
builder.Services.AddTransient<WordInitialData>();
builder.Services.AddTransient<StatusInitialData>();
builder.Services.AddTransient<FlashCardInitialData>();

builder.Services.AddTransient<IWordRepository, WordRepository>();

builder.Services.AddTransient<ITranslateService, TranslateService>();
builder.Services.AddTransient<IWordService, WordService>();

//Validators
builder.Services.AddValidatorsFromAssembly(assembly);

//AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

//Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));

//Amazon IAM
builder.Services.AddSingleton<IAmazonTranslate>(sp =>
{
    var accessKey = builder.Configuration["AWS:AccessKey"];
    var secretKey = builder.Configuration["AWS:SecretKey"];

    var credentials = new BasicAWSCredentials(accessKey, secretKey);

    var config = new AmazonTranslateConfig
    {
        RegionEndpoint = Amazon.RegionEndpoint.EUNorth1
    };

    return new AmazonTranslateClient(credentials, config);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

////InitData
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var wordInitialData = services.GetRequiredService<WordInitialData>();
        var statusInitalData = services.GetRequiredService<StatusInitialData>();
        var flashCardInitalData = services.GetRequiredService<FlashCardInitialData>();

        await statusInitalData.Handle();
        await wordInitialData.Handle();
        await flashCardInitalData.Handle();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();