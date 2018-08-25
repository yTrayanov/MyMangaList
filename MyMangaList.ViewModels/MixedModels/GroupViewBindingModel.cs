using MyMangaList.ViewModels.BindingModels;
using MyMangaList.ViewModels.ViewModels;
using System.Collections.Generic;

namespace MyMangaList.ViewModels.MixedModels
{
    public class GroupViewBindingModel
    {
        public int GroupId { get; set; }

        public string GroupTitle { get; set; }

        public MessageBindingModel BindingModel { get; set; }

        public ICollection<MessageViewModel> ViewModel { get; set; }
    }
}
