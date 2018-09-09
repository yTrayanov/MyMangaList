namespace MyMangaList.DtoModels.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class CommentBindingModel
    {
        public int MangaId { get; set; }

        [Required]
        public string Content { get; set; }

    }
}
