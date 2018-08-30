namespace MyMangaList.Services
{
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using MyMangaList.Data;
    using MyMangaList.Models;
    using System.Linq;
    using Constants;
    public class Service
    {
        protected Service(MyMangaListContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public MyMangaListContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public User FindUserByName(string username)
        {
            var user = this.Context.Users
                .FirstOrDefault(u => u.UserName == username);

            return user;
        }

        public void SendRequest(string currentUserName, string friendName, string type)
        {
            var friend = this.FindUserByName(friendName);
            var currentUser = this.FindUserByName(currentUserName);

            var request = new Request()
            {
                UserId = friend.Id,
                Author = currentUserName,
                Content = type == Constants.FriendRequestString ?
                $"Friend request from {currentUserName}" :
                $"You are invited to {currentUserName} group",
            };

            this.Context.Requests.Add(request);
            this.Context.SaveChanges();
        }
    }
}
