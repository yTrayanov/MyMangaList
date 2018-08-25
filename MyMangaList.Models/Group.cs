using System.Collections.Generic;

namespace MyMangaList.Models
{
    public class Group
    {
        public Group()
        {
            this.Users = new List<UsersInGroups>();
            this.Messages = new List<Message>();
        }

        public int Id { get; set; }
        
        public string Creator { get; set; }
        
        public string Title { get; set; }

        public ICollection<UsersInGroups> Users { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
