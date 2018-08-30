namespace MyMangaList.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int MangaId { get; set; }
        public Manga Manga { get; set; }
    }
}
