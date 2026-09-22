using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Dtos;

public record class CreateNewBook(
    [Required] [StringLength(50)] string Name,
    [Required] [StringLength(20)] string Genre,
    [Range(1, 2000)]int Pages,
    [Range(1, 400)]decimal Price,
    DateOnly ReleaseDate
);