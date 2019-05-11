using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbScraper.Model
{




    public class EdgeFollowedBy
    {
        public int count { get; set; }
    }

    public class EdgeFollow
    {
        public int count { get; set; }
    }

    public class EdgeMutualFollowedBy
    {
        public int count { get; set; }
        public List<object> edges { get; set; }
    }

    public class User
    {
        public string biography { get; set; }
        public bool blocked_by_viewer { get; set; }
        public bool country_block { get; set; }
        public object external_url { get; set; }
        public object external_url_linkshimmed { get; set; }
        public EdgeFollowedBy edge_followed_by { get; set; }
        public bool followed_by_viewer { get; set; }
        public EdgeFollow edge_follow { get; set; }
        public bool follows_viewer { get; set; }
        public string full_name { get; set; }
        public bool has_channel { get; set; }
        public bool has_blocked_viewer { get; set; }
        public int highlight_reel_count { get; set; }
        public bool has_requested_viewer { get; set; }
        public string id { get; set; }
        public bool is_business_account { get; set; }
        public bool is_joined_recently { get; set; }
        public object business_category_name { get; set; }
        public bool is_private { get; set; }
        public bool is_verified { get; set; }

        public string profile_pic_url { get; set; }
        public string profile_pic_url_hd { get; set; }
        public bool requested_by_viewer { get; set; }
        public string username { get; set; }
    }

    public class InstaUser
    {
        public User user { get; set; }
    }
}
