namespace BookStore.Api.Dtos;

public record class Book(
    int Id,
    string Name,
    string Genre,
    int Pages,
    decimal Price,
    DateOnly ReleaseDate

);