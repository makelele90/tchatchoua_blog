using System;
using System.Collections;
using System.Collections.Generic;

namespace Blog.Data
{
    public class User
    {
        public User()
        {
            Post = new HashSet<BlogPost>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public DateTime JoinDate { get; set; }  
        public DateTime? LastLogin { get; set; }
        public ICollection<BlogPost> Post { get; set; }
    }
}
