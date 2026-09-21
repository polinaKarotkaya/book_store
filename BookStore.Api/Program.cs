using BookStore.Api.Dtos;

const string GetBookEndpointName = "GetBook";

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

app.MapGet("/books/{id}", (int id) => {
   var book = books.Find(book => book.Id == id);

   return book is null ? Results.NotFound() : Results.Ok(book);
    
    })
  .WithName(GetBookEndpointName);

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
    return Results.CreatedAtRoute(GetBookEndpointName, new {id = book.Id}, book);

});

app.MapPut("/books/{id}", (int id, UpdateBook updatebook) =>
{
    var index = books.FindIndex(book => book.Id == id);

    if(index == -1)
    {
        return Results.NotFound();
    }
    
    books[index] = new Book(
        id,
        updatebook.Name,
        updatebook.Genre,
        updatebook.Pages,
        updatebook.Price,
        updatebook.ReleaseDate
    );

    return Results.NoContent();
});

app.MapDelete("books/{id}", (int id) =>
{
    books.RemoveAll(book => book.Id == id);

    return Results.NoContent();
});


app.Run();
