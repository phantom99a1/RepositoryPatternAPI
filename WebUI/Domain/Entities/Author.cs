namespace WebUI.Domain.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public DateTime? CreateDateTime { get; set; }
        public string CreateUser { get; set; } = string.Empty;
        public DateTime? LastModifiedDateTime { get; set; }
        public string LastModifiedUser { get; set; } = string.Empty;

        public ICollection<Book> Books { get; set; } = [];
    }
}
