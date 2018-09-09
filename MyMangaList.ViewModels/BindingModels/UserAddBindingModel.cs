namespace MyMangaList.DtoModels.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class UserAddBindingModel
    {
        [Required]
        public string Username { get; set; }
    }
}
