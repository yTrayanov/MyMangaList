namespace MyMangaList.Services.Users
{
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using MyMangaList.Data;
    using MyMangaList.Models;
    using MyMangaList.DtoModels.MixedModels;
    using MyMangaList.DtoModels.ViewModels;
    using Constants;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public class HomeService : Service
    {
        public HomeService(MyMangaListContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public UsersVewBindingModel GetUserFriends(string userName)
        {
            var friends = this.Context.Friends
                .Include(f => f.User)
                .Include(f => f.Contract)
                .Where(f => f.User.UserName == userName || f.Contract.UserName == userName)
                .ToList();
            List<User> users = GetAllFriends(friends , userName);

            var friendsCollection = this.Mapper.Map<IEnumerable<UsersViewModel>>(users);

            var model = new UsersVewBindingModel()
            {
                ViewModel = friendsCollection.ToList(),
            };

            return model;
        }

        public IEnumerable<MangaDetailsViewModel> GetAllManga()
        {
            var mangas = this.Context.Manga;
            var models = this.Mapper.Map<IEnumerable<MangaDetailsViewModel>>(mangas);

            return models;
        }

        public void AddFriend(string currentUserName , string friendName)
        {
            var friend = FindUserByName(friendName);
            var currentUser = FindUserByName(currentUserName);

            
            var contract = new Friend()
            {
                UserId = currentUser.Id,
                ContractId = friend.Id,
            };

            this.Context.Friends.Add(contract);
            this.Context.SaveChanges();
        }

        

        public void RemoveFriend(string username , string currentUserName)
        {
            var friendUser = this.FindUserByName(username);

            var friend = this.Context.Friends
                .Include(f => f.User)
                .FirstOrDefault(f => f.User.UserName == currentUserName
                                && f.ContractId == friendUser.Id);

            this.Context.Friends.Remove(friend);
            this.Context.SaveChanges();
        }

        

        private List<User> GetAllFriends(List<Friend> friends ,string currentUserName)
        {
            var users = new List<User>();
            foreach (var friend in friends)
            {
                if (friend.User.UserName == currentUserName)
                {
                    users.Add(this.Context.Users.FirstOrDefault(u => u.Id == friend.ContractId));
                }
                else
                {
                    users.Add(this.Context.Users.FirstOrDefault(u => u.Id == friend.UserId));
                }
            }

            return users;
        }

    }
}
