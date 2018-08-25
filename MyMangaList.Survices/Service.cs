using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MyMangaList.Data;
using MyMangaList.Models;

namespace MyMangaList.Services
{
    public class Service
    {
        protected Service(MyMangaListContext context, UserManager<User> userManager , IMapper mapper)
        {
            this.Context = context;
            this.UserManager = userManager;
            this.Mapper = mapper;
        }

        public MyMangaListContext Context { get; set; }
        public UserManager<User> UserManager { get; set; }
        public IMapper Mapper { get; set; }
    }
}
