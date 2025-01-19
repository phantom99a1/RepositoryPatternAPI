﻿namespace WebUI.Domain.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;

        public ICollection<Book> Books { get; set; } = [];
    }
}
