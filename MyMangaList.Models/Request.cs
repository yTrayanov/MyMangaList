namespace MyMangaList.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Request
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Author { get; set; }
        
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
