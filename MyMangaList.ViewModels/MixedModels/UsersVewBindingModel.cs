namespace MyMangaList.DtoModels.MixedModels
{
    using System.Collections.Generic;
    using BindingModels;
    using ViewModels;

    public class UsersVewBindingModel
    {
        public UsersVewBindingModel()
        {
            this.ViewModel = new List<UsersViewModel>();
        }

        public UserAddBindingModel BindingModel { get; set; }

        public ICollection<UsersViewModel> ViewModel { get; set; }
    }
}
