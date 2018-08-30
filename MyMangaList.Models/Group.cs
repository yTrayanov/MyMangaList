namespace MyMangaList.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Group
    {
        public Group()
        {
            this.Users = new List<UsersInGroups>();
            this.Messages = new List<Message>();
        }

        public int Id { get; set; }
        
        [Required]
        public string Creator { get; set; }
        
        [Required]
        public string Title { get; set; }

        public ICollection<UsersInGroups> Users { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
