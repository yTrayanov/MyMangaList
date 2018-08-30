using MyMangaList.DtoModels.BindingModels;
using MyMangaList.DtoModels.ViewModels;
using System.Collections.Generic;

namespace MyMangaList.DtoModels.MixedModels
{
    public class CommentViewBindingModel
    {
        public CommentViewBindingModel()
        {
            this.ViewModels = new List<CommentViewModel>();
        }

        public CommentBindingModel BindingModel { get; set; }

        public ICollection<CommentViewModel> ViewModels { get; set; }
    }
}
