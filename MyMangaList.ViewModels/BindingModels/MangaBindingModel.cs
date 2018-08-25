using System.ComponentModel.DataAnnotations;

namespace MyMangaList.ViewModels.BindingModels
{
    public class MangaBindingModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        [Required]
        [MinLength(255,ErrorMessage = "Story must be at least 255 symbols!")]
        public string Story { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        }
}
