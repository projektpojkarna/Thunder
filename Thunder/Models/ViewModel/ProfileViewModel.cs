using System.Collections.Generic;
using Thunder.Models.ViewModel;

namespace Thunder.Models
{
    public class ProfileViewModel
    {
        public Profile Profile { get; set; }
        public List<FriendViewModel> Friends { get; set; }
        public List<Post> Posts { get; set; }
    }
}