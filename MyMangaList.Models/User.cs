using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MyMangaList.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.MyMangaList = new List<UserManga>();
            this.MangaWritten = new List<Manga>();
            this.Groups = new List<UsersInGroups>();
            this.Comments = new List<Comment>();
            this.Friends = new List<Friend>();
        }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<UserManga> MyMangaList { get; set; }

        public ICollection<Manga> MangaWritten { get; set; }

        public ICollection<UsersInGroups> Groups { get; set; }


        public ICollection<Friend> UserContracts { get; set; }
        public ICollection<Friend> Friends { get; set; }
    }
}
