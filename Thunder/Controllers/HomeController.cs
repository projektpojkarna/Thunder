using Microsoft.AspNet.Identity;
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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult _FriendRequestPartial()
        {
            var uId = User.Identity.GetUserId();
            var fRequests = new FriendRequestDbContext().
                Requests.Where(u => u.RecieverId == uId).ToList();

            var frqSenderIds = fRequests.Select(f => f.SenderId).ToList();

            var fProfiles = new ProfileDbContext().Profiles.Where(p => frqSenderIds.Contains(p.UserId)).ToList();

           /* var fProfiles = new ProfileDbContext().Profiles.Where(p =>
                (fRequests.Select(f => f.SenderId).Contains(p.UserId))).ToList();*/




            var fReqList = new List<FriendViewModel>();
            foreach(var p in fProfiles)
            {
                fReqList.Add(FriendViewModel.FromProfile(p));
            }

            return PartialView("_FriendRequestPartial", fReqList);
        }
    }
}