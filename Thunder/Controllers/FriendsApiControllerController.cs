using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Thunder.Models;
using Thunder.Models.User;

namespace Thunder.Controllers
{
    [Authorize]
    [RoutePrefix("api/friends")]
    public class FriendsApiControllerController : ApiController
    {
 
        private void RemoveFromRequests(string userId, string friendUserId)
        {
            var ctx = new FriendRequestDbContext();
            var reqToRemove = ctx.Requests.
                SingleOrDefault(r => r.RecieverId == userId && r.SenderId == friendUserId);
            if(reqToRemove != null)
            {
                ctx.Requests.Remove(reqToRemove);
            }
            ctx.SaveChanges();
        }

        [HttpGet]
        [Route("add/addfriend")]
        public void AddFriend(string userID)
        {
            var currentUserId = User.Identity.GetUserId();
            var ctx = new FriendsDbContext();
            var alreadyFriends = ctx.Friends.Any(u => u.UserID == currentUserId && u.FriendUserId == userID);
            if(! alreadyFriends)
            {
                ctx.Friends.Add(new Friends()
                {
                    UserID = currentUserId,
                    FriendUserId = userID
                });
                RemoveFromRequests(currentUserId, userID);
            }
            ctx.SaveChanges();
        }
        
    }
}
