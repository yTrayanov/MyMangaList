namespace MyMangaList.DtoModels.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class MessageBindingModel
    {
        [Required]
        public string Content { get; set; }
        
    }
}
