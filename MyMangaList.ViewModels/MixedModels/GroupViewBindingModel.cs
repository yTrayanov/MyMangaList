using MyMangaList.DtoModels.BindingModels;
using MyMangaList.DtoModels.ViewModels;
using System.Collections.Generic;

namespace MyMangaList.DtoModels.MixedModels
{
    public class GroupViewBindingModel
    {
        public int GroupId { get; set; }

        public string GroupTitle { get; set; }

        public MessageBindingModel BindingModel { get; set; }

        public ICollection<MessageViewModel> ViewModel { get; set; }
    }
}
