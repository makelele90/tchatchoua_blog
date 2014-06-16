using System;
using System.Collections;
using System.Collections.Generic;

namespace Blog.Data
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public User CreatedBy { get; set; }
        public User LastUpdatedBy { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<PostComment> Comment { get; set; }
    }
}
