using System;
using System.Collections.Generic;

namespace MyMangaList.Models
{
    public class Manga
    {
        public Manga()
        {
            this.Comments = new List<Comment>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Story { get; set; }

        public string Genre { get; set; }

        public string Image { get; set; }

        public DateTime Date { get; set; }

        public DateTime LastUpdated { get; set; }

        public string AuthorId { get; set; }
        public User Author { get; set; }

        public ICollection<UserManga> Users { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
