namespace MyMangaList.DtoModels.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class GroupBindingModel
    {
        [Required]
        public string Title { get; set; }
        
    }
}
