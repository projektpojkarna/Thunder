using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thunder.Models;
using Thunder.Models.User;
using Thunder.Models.ViewModel;

namespace Thunder.Controllers
{
    [Authorize] //Alla vyer i denna kontroller kräver inlogg
    public class UserController : Controller
    {

        private ProfileViewModel GetProfileViewModel(string userId)
        {
            var profileCtx = new ProfileDbContext();
            var friendCtx = new FriendsDbContext();
            var postCtx = new PostDbContext();
            var ImgCtx = new ImageDbContext();

            var image = ImgCtx.Images.FirstOrDefault(u => u.UserID == userId);

            var profile = profileCtx.Profiles.FirstOrDefault(p => p.UserId == userId);
            if (profile.Interests == null)
            {
                profile.Interests = new HashSet<string>();
            }

            var posts = postCtx.Posts.Where(po => po.UserId == userId).ToList();
            var friends = friendCtx.Friends.Where(f => f.UserID == userId).ToList();
            var friendList = new List<FriendViewModel>();

            if (friends != null)
            {
                foreach (var f in friends)
                {
                    var friendProfile = profileCtx.Profiles.SingleOrDefault(p => p.UserId == f.FriendUserId);
                    friendList.Add(FriendViewModel.FromProfile(friendProfile));
                }
            }

            return new ProfileViewModel()
            {
                Profile = profile,
                Friends = friendList,
                Posts = posts,
                Image = image
            };
        }


        // GET: User
        public ActionResult Index()
        {
            return RedirectToAction("ViewProfile");
        }

        public ActionResult EditProfile()
        {
            var ctx = new ProfileDbContext();
            var userId = User.Identity.GetUserId();
            var profileViewModel = GetProfileViewModel(userId);

            return View(profileViewModel);
        }

        [HttpPost]
        public ActionResult EditProfile(ProfileViewModel p)
        {
            var ctx = new ProfileDbContext();
            var userId = User.Identity.GetUserId();
            var profile = ctx.Profiles.FirstOrDefault(pr => pr.UserId == userId);
            profile.Location = p.Profile.Location;
            profile.Occupation = p.Profile.Occupation;
            profile.Presentation = p.Profile.Presentation;
            ctx.SaveChanges();

            return RedirectToAction("ViewProfile");
        }

        public ActionResult ViewProfile(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                userId = User.Identity.GetUserId();
            }
            var profileViewModel = GetProfileViewModel(userId);
            return View(profileViewModel);
        }

        [HttpGet]
        public ActionResult SendFriendRequest(string userId)
        {
            if (userId != User.Identity.GetUserId())
            {
                var ctx = new FriendRequestDbContext();
                ctx.Requests.Add(new FriendRequest()
                {
                    SenderId = User.Identity.GetUserId(),
                    RecieverId = userId
                });
                ctx.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult _DisplayPostsPartial(string userId)
        {
            var posts = new PostDbContext().Posts.Where(p => p.UserId == userId).ToList();
            var authors = new ProfileDbContext().Profiles.ToList();
            var postList = new List<PostViewModel>();

            foreach (var p in posts)
            {
                var author = authors.FirstOrDefault(a => a.UserId == p.Author_UserId);

                postList.Add(new PostViewModel()
                {
                    Author_UserId = p.Author_UserId,
                    Author_FullName = string.Concat(author.FirstName, " ", author.LastName),
                    Text = p.Text,
                    UserId = p.UserId
                });
            }
            return PartialView(postList);
        }
    }
}