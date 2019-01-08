using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thunder.Models;
using Thunder.Models.ViewModel;

namespace Thunder.Controllers
{
    [Authorize] //Alla vyer i denna kontroller kräver inlogg
    public class UserController : Controller
    {
        private ApplicationUser GetCurrentUser()
        {
            var userId = User.Identity.GetUserId();
            var manager =
                new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = manager.FindById(userId);
            return user;
        }

        private ProfileViewModel GetProfileViewModel(string userId)
        {
            var profileCtx = new ProfileDbContext();
            var friendCtx = new FriendListDbContext();
            var postCtx = new PostDbContext();

            var friendList = new List<FriendViewModel>();

            var profile = profileCtx.Profiles.FirstOrDefault(p => p.UserId == userId);
            var posts = postCtx.Posts.Where(po => po.UserId == userId).ToList();

            var friends = friendCtx.Friends.FirstOrDefault(u => u.UserId == userId);
            if (friends != null)
            {
                foreach (var f in friends.Friend_UserIds)
                {
                    var friendProfile = profileCtx.Profiles.SingleOrDefault(p => p.UserId == f);
                    friendList.Add(FriendViewModel.FromProfile(friendProfile));
                }
            }

            return new ProfileViewModel()
            {
                Profile = profile,
                Friends = friendList,
                Posts = posts
            };
        }


        // GET: User
        public ActionResult Index()
        {
            return View();
        }

     
        public ActionResult EditProfile()
        {
            var ctx = new ProfileDbContext();
            var userId = User.Identity.GetUserId();
            var profileViewModel = GetProfileViewModel(userId);

            return View(profileViewModel);
        }

        public ActionResult ViewProfile(string userId)
        {
            if(string.IsNullOrEmpty(userId))
            {
                userId = User.Identity.GetUserId();
            }
            var profileViewModel = GetProfileViewModel(userId);
            return View(profileViewModel);
        }
    }
}