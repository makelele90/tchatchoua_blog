using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Data.Reppository
{
    public class UserRepository: GenericRepository<User, BlogDataContext>
    {
        public IEnumerable<User> GetAll() {

            return FindAll().ToList();
        }
    }
}
