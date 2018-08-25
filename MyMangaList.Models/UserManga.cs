namespace MyMangaList.Models
{
    public class UserManga
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int MangaId { get; set; }
        public Manga Manga { get; set; }
    }
}
