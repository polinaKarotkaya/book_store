using BookStore.Api.Enpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

var app = builder.Build();

app.MapBooksEndpoints();

app.Run();
