namespace WebUI.Domain.Contracts
{
    public record CreateBook
    {
        public string Title { get; init; } = string.Empty;
        public double Price { get; init; }
        public string Description { get; init; } = string.Empty;
        public Guid AuthorId { get; init; }
    }

    public record UpdateBook
    {
        public string Title { get; init; } = string.Empty;
        public double Price { get; init; }
        public string Description { get; init; } = string.Empty;
        public Guid AuthorId { get; init; }
    }

    public record DeleteBook
    {
        public Guid Id { get; init; }
    }

    public record GetBook
    {
        public Guid Id { get; init; }
    }

    public class GetBookDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;   
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public Guid AuthorId { get; set; }
    }
}
