using Blog.Data.Reppository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new UserRepository();


            var users = repo.GetAll();

            
            Console.Read();
        }
    }
}
