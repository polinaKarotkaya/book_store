using BookStore.Api.Dtos;
using BookStore.Api.Enpoints;



var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapBooksEndpoints();

app.Run();
