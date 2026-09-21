using BookStore.Api.Dtos;
using Microsoft.VisualBasic;

namespace BookStore.Api.Enpoints;

public static  class BookEndpoints
{
    const string GetBookEndpointName = "GetBook";

    private static readonly List<Book> books = [
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

public static void MapBooksEndpoints(this WebApplication app)
    {

    var group = app.MapGroup("/books");   

    group.MapGet("", () => "Hello World!");
    group.MapGet("/", () => books);

    group.MapGet("/{id}", (int id) => {
    var book = books.Find(book => book.Id == id);

    return book is null ? Results.NotFound() : Results.Ok(book);
    
     })
    .WithName(GetBookEndpointName);

    group.MapPost("/", (CreateNewBook newBook) =>
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

group.MapPut("/{id}", (int id, UpdateBook updatebook) =>
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

group.MapDelete("/{id}", (int id) =>
{
    books.RemoveAll(book => book.Id == id);

    return Results.NoContent();
});

    }

}