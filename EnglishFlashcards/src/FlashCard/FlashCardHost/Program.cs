using Amazon.Runtime;
using Amazon.Translate;
using FlashCard.Host.Mappings;
using FlashCard.Host.Services.Abstractions;
using FlashCard.Host.Services.WordService;
using FlashCard.Host.Services.TranslateService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Services
builder.Services.AddTransient<ITranslateService, TranslateService>();
builder.Services.AddTransient<IWordService, WordService>();

//AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
