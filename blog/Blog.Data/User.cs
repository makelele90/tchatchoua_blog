using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Blog.Data
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public DateTime JoinDate { get; set; }  
        public DateTime? LastLogin { get; set; }
        public virtual ICollection<BlogPost> Posts { get; set; }
        public virtual ICollection<Role> Roles { get; set; } 
    }
}
