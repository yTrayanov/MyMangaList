namespace MyMangaList.Services.Users
{
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using MyMangaList.Data;
    using MyMangaList.DtoModels.MixedModels;
    using MyMangaList.DtoModels.ViewModels;
    using MyMangaList.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class GroupService : Service
    {
        public GroupService(MyMangaListContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        public IEnumerable<GroupViewModel> GetAllGroups(string username)
        {
            var usersInGroups = this.Context
                .UsersInGrouos
                .Include(ug => ug.User)
                .Where(ug => ug.User.UserName == username)
                .ToList();

            List<Group> groups = GetUserGroups(username, usersInGroups);
            List<GroupViewModel> models = MapToModels(groups);

            return models;
        }

        public int CreateGroup(string title , string username)
        {
            var group = new MyMangaList.Models.Group()
            {
                Title = title,
                Creator =username
            };

            var currentUser = FindUserByName(username);

            var userGroup = new UsersInGroups()
            {
                User = currentUser,
                Group = group
            };
            this.Context.UsersInGrouos.Add(userGroup);
            this.Context.SaveChanges();

            return group.Id;
        }

        //Find a way to use automapper!
        public GroupViewModel GetDetailsOfGroup(int id)
        {
            var userGroup = this.Context
                .UsersInGrouos
                .Where(g => g.GroupId == id)
                .ToList();

            var group = this.Context.Groups.Find(id);

            // Mapper.Map<GroupViewModel>(group);

            var model = new GroupViewModel()
            {
                Title = group.Title,
                Creator = group.Creator,
                Members = new List<User>()

            };

            foreach (var member in userGroup)
            {
                var user = this.Context.Users.FirstOrDefault(u => u.Id == member.UserId);
                model.Members.Add(user);
            }

            return model;
        }

        public int AddUserToGroup(int id , string userId)
        {
            var group = this.Context.Groups.Find(id);
            var userGroup = new UsersInGroups() { UserId = userId, GroupId = id };

            if (!this.Context.UsersInGrouos.Contains(userGroup))
            {
                this.Context.UsersInGrouos.Add(userGroup);
                this.Context.SaveChanges();
            }

            return group.Id;

        }

        public void LeaveGroup(string username , int groupId)
        {
            var userInGroup = this.Context
                .UsersInGrouos
                .Include(u => u.User)
                .FirstOrDefault(g => g.User.UserName == username && g.GroupId == groupId);

            this.Context.UsersInGrouos.Remove(userInGroup);
            this.Context.SaveChanges();

            CheckIfThereAreAnyUsersLeft(groupId);
        }



        public GroupViewBindingModel GetAllMessagesOfGroup(int id)
        {
            var messages = this.Context.Messages
                .Include(m => m.User)
                .Where(m => m.GroupId == id)
                .ToList();

            var groupName = this.Context.Groups.FirstOrDefault(g => g.Id == id).Title;

            var messagesCollection = this.Mapper
                .Map<IEnumerable<MessageViewModel>>(messages)
                .ToList();

            var model = new GroupViewBindingModel()
            {
                GroupId = id,
                GroupTitle = groupName,
                ViewModel = messagesCollection,
            };

            return model;
        }

        public void AddMessageToGroup(int id,string username , string content)
        {
            var group = this.Context.Groups.FirstOrDefault(g => g.Id == id);
            var currentUser = this.FindUserByName(username);

            var message = new Message()
            {
                User = currentUser,
                Group = group,
                Content = content
            };



            this.Context.Messages.Add(message);
            this.Context.SaveChanges();
        }





        private void CheckIfThereAreAnyUsersLeft(int groupId)
        {
            var group = this.Context.Groups.Find(groupId);
            var membersLeft = this.Context.UsersInGrouos
                .Any(ug => ug.GroupId == groupId);

            if (!membersLeft)
            {
                this.Context.Groups.Remove(group);
                this.Context.SaveChanges();
            }
        }

        //Auto Mapper can be used here!!!
        private static List<GroupViewModel> MapToModels(List<Group> groups)
        {
            var models = new List<GroupViewModel>(); //Mapper.Map<IEnumerable<GroupViewModel>>(groups);
            
            foreach (var group in groups)
            {
                var gv = new GroupViewModel()
                {
                    Id = group.Id,
                    Title = group.Title,
                };
                models.Add(gv);
            }

            return models;
        }

        private List<Group> GetUserGroups(string username, List<UsersInGroups> usersInGroups)
        {
            var groups = new List<MyMangaList.Models.Group>();

            foreach (var userInGroup in usersInGroups)
            {
                if (userInGroup.User.UserName == username)
                {
                    var group = this.Context.Groups.FirstOrDefault(g => g.Id == userInGroup.GroupId);
                    groups.Add(group);
                }
            }

            return groups;
        }

        
    }
}
