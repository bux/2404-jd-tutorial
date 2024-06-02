using ChatApi;
using Microsoft.AspNetCore.Mvc;

var config = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .Build();

var endpoint = config["AZURE_OPENAI_ENDPOINT"];
var deployment = config["AZURE_OPENAI_GPT_NAME"];
var key = config["AZURE_OPENAI_KEY"];

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
        policy.WithOrigins("http://localhost", "http://localhost:80", "http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
    );
});

builder.Services.AddSingleton<IChatService>(new ChatService(deployment, endpoint, key));

var app = builder.Build();
app.UseCors("AllowLocalhost");


app.MapGet("/", () => "Hello World!");

app.MapPost("/messages", async (ChatMessage message, [FromServices] IChatService chatService) =>
{
    if (message.Content == null)
        return Results.BadRequest("Content is required.");

    var result = await chatService.SendMessage(message.Content);
    return Results.Ok(result);
});

app.Run();