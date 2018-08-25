using System;

namespace MyMangaList.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int MangaId { get; set; }
        public Manga Manga { get; set; }
    }
}
