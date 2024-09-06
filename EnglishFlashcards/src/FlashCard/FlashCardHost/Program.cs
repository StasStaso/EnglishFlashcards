using Amazon.Runtime;
using Amazon.Translate;
using FlashCard.Host.Data;
using FlashCard.Host.Data.InitialData;
using FlashCard.Host.Mappings;
using FlashCard.Host.Services.TranslateService;
using FlashCard.Host.Services.WordService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Services
builder.Services.AddTransient<ITranslateService, TranslateService>();
builder.Services.AddTransient<IWordService, WordService>();

builder.Services.AddScoped<WordInitialData>();
builder.Services.AddScoped<StatusInitialData>();
builder.Services.AddScoped<FlashCardInitialData>();

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

//InitData
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var wordInitialData = services.GetRequiredService<WordInitialData>();
    var statusInitalData = services.GetRequiredService<StatusInitialData>();
    var flashCardInitalData = services.GetRequiredService<FlashCardInitialData>();

    await statusInitalData.Handle();
    await wordInitialData.Handle();
    await flashCardInitalData.Handle();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
