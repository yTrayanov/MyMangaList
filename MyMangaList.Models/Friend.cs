namespace MyMangaList.Models
{
    public class Friend
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public string ContractId { get; set; }
        public User Contract { get; set; }
    }
}
