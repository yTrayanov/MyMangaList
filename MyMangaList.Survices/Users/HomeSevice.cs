namespace MyMangaList.Services.Users
{
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using MyMangaList.Data;
    using MyMangaList.Models;
    using MyMangaList.ViewModels.MixedModels;
    using MyMangaList.ViewModels.ViewModels;
    using System.Collections.Generic;
    using System.Linq;

    public class HomeService : Service
    {
        public HomeService(MyMangaListContext context, UserManager<User> userManager, IMapper mapper)
            : base(context, userManager, mapper)
        {
        }

        public UsersVewBindingModel GetUserFriends(string userName)
        {
            var friends = this.Context.Friends.Where(f => f.User.UserName == userName).ToList();
            var users = new List<User>();
            foreach (var friend in friends)
            {

                users.Add(this.Context.Users.FirstOrDefault(u => u.Id == friend.ContractId));
            }

            var friendsCollection = this.Mapper.Map<IEnumerable<UsersViewModel>>(users);

            var model = new UsersVewBindingModel()
            {
                ViewModel = friendsCollection.ToList(),
            };

            return model;
        }

       
    }
}
