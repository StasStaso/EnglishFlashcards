using Amazon.Runtime;
using Amazon.Translate;
using FlashCard.Host.Services;
using FlashCard.Host.Services.Abstractions;
using FlashCardHost.Services.TranslateService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ITranslateService, TranslateService>();
builder.Services.AddTransient<IWordService, WordService>();

//
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

//

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
