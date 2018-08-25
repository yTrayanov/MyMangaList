using AutoMapper;
using MyMangaList.Models;
using MyMangaList.ViewModels.ViewModels;

namespace MyMangaList.Mapper.Mapping
{
    public class AuthoMapperProfile:Profile
    {
        public AuthoMapperProfile()
        {
            this.CreateMap<User, UserConsiceViewModel>();
            this.CreateMap<User, UserDetailsViewModel>();
            this.CreateMap<User, UsersViewModel>();
            this.CreateMap<Manga, MangaDetailsViewModel>()
                .ForMember(mv => mv.Author, src => src.MapFrom(m => m.Author.UserName));
            this.CreateMap<Manga, StoryViewModel>()
                .ForMember(sv=>sv.MangaId , src =>src.MapFrom(m => m.Id));
            this.CreateMap<Group, GroupViewModel>()
                .ForMember(gv => gv.Members, src => src.MapFrom(g => g.Users));
            this.CreateMap<Message, MessageViewModel>()
                .ForMember(mv => mv.User, src => src.MapFrom(m => m.User.UserName));
            
        }
    }
}
