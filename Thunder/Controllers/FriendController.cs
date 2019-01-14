using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thunder.Models;
using Thunder.Models.User;

namespace Thunder.Controllers
{
    public class FriendController : Controller
    {
        //Ta vort från vänförfrågning
        private void RemoveFromRequests(string userId, string friendUserId)
        {
            var ctx = new FriendRequestDbContext();
            var reqToRemove = ctx.Requests.
                SingleOrDefault(r => r.RecieverId == userId && r.SenderId == friendUserId);
            if (reqToRemove != null)
            {
                ctx.Requests.Remove(reqToRemove);
            }
            ctx.SaveChanges();
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

        //Avböj vänförfrågan
        public ActionResult DenyFriendRequest(string userId)
        {
            var currentUserId = User.Identity.GetUserId();
            var ctx = new FriendRequestDbContext();
            var request = ctx.Requests.FirstOrDefault(r => r.RecieverId == currentUserId && r.SenderId == userId);
            if (request != null)
            {
                ctx.Requests.Remove(request);
                ctx.SaveChanges();
            }

            return Redirect(Request.UrlReferrer.ToString());
        }

        //Acceptera vänförfrågan
        public ActionResult AcceptFriendRequest(string userId)
        {
            var currentUserId = User.Identity.GetUserId();
            var ctx = new FriendsDbContext();
            var alreadyFriends = ctx.Friends.Any(u => u.UserID == currentUserId && u.FriendUserId == userId);
            if (!alreadyFriends)
            {
                ctx.Friends.Add(new Friend()
                {
                    UserID = currentUserId,
                    FriendUserId = userId
                });
                ctx.Friends.Add(new Friend()
                {
                    FriendUserId = currentUserId,
                    UserID = userId
                });
                RemoveFromRequests(currentUserId, userId);
                ctx.SaveChanges();
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        //Ta bort vän
        public ActionResult RemoveFriend(string userId)
        {
            var currentUserId = User.Identity.GetUserId();
            var ctx = new FriendsDbContext();
            var friendRelationToremove = ctx.Friends.Where(p =>
                ((p.FriendUserId == userId) && (p.UserID == currentUserId)) ||
                ((p.FriendUserId == currentUserId) && (p.UserID == userId))).ToList();

            ctx.Friends.RemoveRange(friendRelationToremove);
            ctx.SaveChanges();
            return RedirectToAction("ViewProfile", "User");
        }
    }
}