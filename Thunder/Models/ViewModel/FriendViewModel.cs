using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thunder.Models.ViewModel
{
    public class FriendViewModel
    {
        public static FriendViewModel FromProfile(Profile p)
        {
            return new FriendViewModel()
            {
                FullName = string.Concat(p.FirstName, " ", p.LastName),
                UserId = p.UserId
            };
        }

        public string UserId { get; set; }
        public string FullName { get; set; }

    }

 

}