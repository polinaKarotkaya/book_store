namespace BookStore.Api.Dtos;

public record UpdateBook(
    string Name,
    string Genre,
    int Pages,
    decimal Price,
    DateOnly ReleaseDate
);
