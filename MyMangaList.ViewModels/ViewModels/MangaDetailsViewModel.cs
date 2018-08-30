using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMangaList.DtoModels.ViewModels
{
    public class MangaDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Story { get; set; }

        public string Genre { get; set; }

        public string Image { get; set; }

        public DateTime Date { get; set; }

        public DateTime LastUpdated { get; set; }

        public string Author { get; set; }
    }
}
