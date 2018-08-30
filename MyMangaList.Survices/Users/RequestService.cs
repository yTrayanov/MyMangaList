namespace MyMangaList.Services.Users
{
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using MyMangaList.Data;
    using MyMangaList.DtoModels.ViewModels;
    using MyMangaList.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class RequestService : Service
    {
        public RequestService(MyMangaListContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        public IEnumerable<RequestViewModel> GetAllRequests(string userId)
        {
            var requests = this.Context.Requests
                .Include(r => r.User)
                .Where(r => r.UserId == userId)
                .ToList();

            List<RequestViewModel> models = MapRequestViewModel(requests);

            return models;
        }

        public void AcceptRequest(string currentUserName , string friendId , int requestId)
        {
            var currentUser = this.FindUserByName(currentUserName);
            var friendUser = this.Context.Users.Find(friendId);

            var friend = new Friend()
            {
                UserId = currentUser.Id,
                ContractId = friendUser.Id
            };

            ChecIfTheyAreFriendsAndAdd(friend);
            RemoveRequestFromContext(requestId);
        }

        
        public void DeclineRequest(int requestId)
        {
            this.RemoveRequestFromContext(requestId);
        }

        private void RemoveRequestFromContext(int requestId)
        {
            var request = this.Context.Requests.Find(requestId);
            this.Context.Requests.Remove(request);
            this.Context.SaveChanges();
        }


        private void ChecIfTheyAreFriendsAndAdd(Friend friend)
        {
            bool AreTheyFriends = this.Context.Friends.Any(f => (f.UserId == friend.UserId && f.ContractId == friend.ContractId)
                                                                || (f.UserId == friend.ContractId && f.ContractId == friend.UserId));
            if (!AreTheyFriends)
            {
                this.Context.Friends.Add(friend);
                this.Context.SaveChanges();
            }
        }

        private List<RequestViewModel> MapRequestViewModel(IEnumerable<Request> requests)
        {
            var models = new List<RequestViewModel>();
            foreach (var request in requests)
            {
                var user = this.FindUserByName(request.Author);

                var viewModel = new RequestViewModel()
                {
                    Content = request.Content,
                    AuthorId = user.Id,
                    RequestId = request.Id
                };
                models.Add(viewModel);
            }

            return models;
        }
    }
}
