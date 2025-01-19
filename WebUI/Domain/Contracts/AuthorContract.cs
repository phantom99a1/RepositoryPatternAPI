namespace WebUI.Domain.Contracts
{
    public record CreateAuthor
    {
        public string Name { get; init; } = string.Empty;
        public string Bio { get; init; } = string.Empty;
    }

    public record UpdateAuthor
    {
        public string Name { get; init; } = string.Empty;
        public string Bio { get; init; } = string.Empty;
    }

    public record DeleteAuthor
    {
        public Guid Id { get; init; }
    }

    public record GetAuthor
    {
        public Guid Id { get; init; }
    }


    public class GetAuthorDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public ICollection<GetBookDTO> Books { get; set; } = [];
    }
}
