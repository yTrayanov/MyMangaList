using MyMangaList.ViewModels.BindingModels;
using MyMangaList.ViewModels.ViewModels;
using System.Collections.Generic;

namespace MyMangaList.ViewModels.MixedModels
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
