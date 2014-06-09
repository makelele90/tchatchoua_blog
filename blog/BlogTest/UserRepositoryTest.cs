using Blog.Data.Reppository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogTest
{
    [TestFixture]
    public class UserRepositoryTest
    {
        private UserRepository repo;

        [SetUp]
        public void Init()
        {
            repo = new UserRepository();
        }

        [Test]
        public void GetAllUser_should_not_be_empty()
        {
           
        }
    }
}
