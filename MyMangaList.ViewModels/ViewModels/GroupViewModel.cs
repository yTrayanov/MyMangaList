using MyMangaList.Models;
using System.Collections.Generic;

namespace MyMangaList.DtoModels.ViewModels
{
    public class GroupViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<User> Members { get; set; }
        public string Creator { get; set; }
    }
}
