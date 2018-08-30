using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMangaList.Data;
using MyMangaList.DtoModels.ViewModels;
using MyMangaList.Models;
using MyMangaList.Services.Users;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMangaList.Web.Areas.Users.Controllers
{
    public class RequestController : UsersController
    {
        private RequestService requestService;

        public RequestController(UserManager<User> userManager , RequestService requestService) 
            : base(userManager)
        {
            this.requestService = requestService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var currentUser = await this.UserManager.GetUserAsync(this.User);
            var models = this.requestService.GetAllRequests(currentUser.Id);

            return this.View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Accept(int requestId, string userId )
        {
            var currentUser = await this.UserManager.GetUserAsync(this.User);

            this.requestService.AcceptRequest(currentUser.UserName, userId, requestId);

            return RedirectToAction("Index" , "Request");
        }

        public IActionResult Decline(int requestId)
        {
            this.requestService.DeclineRequest(requestId);
            return RedirectToAction("Index", "Request");
        }

    }
}