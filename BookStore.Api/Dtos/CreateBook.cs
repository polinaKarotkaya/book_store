namespace BookStore.Api.Dtos;

public record class CreateNewBook(
   string Name,
    string Genre,
    int Pages,
    decimal Price,
    DateOnly ReleaseDate
);