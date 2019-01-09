using System.Collections.Generic;
using Thunder.Models.ViewModel;
using Thunder.Models.User;

namespace Thunder.Models
{
    public class ProfileViewModel
    {
        public Profile Profile { get; set; }
        public Image Image { get; set; }
        public List<FriendViewModel> Friends { get; set; }
        public List<Post> Posts { get; set; }
    }
}