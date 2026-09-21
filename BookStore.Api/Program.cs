using BookStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Book> books = [
    new (1,
    "Little Woman",
    "novel",
    500,
    26.20M,
    new DateOnly(1956, 6, 20)),
    new (2,
    "lala",
    "lolo",
    1000,
    150.20M,
    new DateOnly(3000, 2, 1)),
];

app.MapGet("/", () => "Hello World!");
app.MapGet("/books", () => books);
app.MapGet("/books/{id}", (int id) => books.Find(books => books.Id == id))
  .WithName("GetBook");

app.MapPost("/books", (CreateNewBook newBook) =>
{
    Book book = new(
        books.Count + 1,
        newBook.Name,
        newBook.Genre,
        newBook.Pages,
        newBook.Price,
        newBook.ReleaseDate
    );

    books.Add(book);
    return Results.CreatedAtRoute("GetBook")

});


app.Run();
