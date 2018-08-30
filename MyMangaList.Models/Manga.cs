namespace MyMangaList.Models
{
    using Constants;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Manga
    {
        public Manga()
        {
            this.Comments = new List<Comment>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [MinLength(Constants.ShortDescriptionMinLenght)]
        public string ShortDescription { get; set; }

        [Required]
        [MinLength(Constants.StoryMinLenght)]
        public string Story { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public DateTime LastUpdated { get; set; }

        public string AuthorId { get; set; }
        public User Author { get; set; }

        public ICollection<UserManga> Users { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
