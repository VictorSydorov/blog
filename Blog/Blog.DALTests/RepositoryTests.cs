using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DAL;
using Blog.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Blog.DAL.Tests
{
    [TestClass()]
    public class RepositoryTests
    {
        private IRepository<User> userRepository;

        private IRepository<User> Repo
        {
            get { if(userRepository==null)
                     userRepository=new Repository<User>(conName);
                return userRepository;
                }
        }
        private string conName = "db";
        [TestInitialize]
        public void Start()
        {
           
            User user = new User
            {
                UserName = "Demo",
                Password = "Demo"
            };
           Repo.Add(user);
        }
        [TestCleanup]
        public void Cleanup()
        {
            if (Repo != null)
            {
                var all = Repo.GetAll().ToList();
                foreach (var e in all)
                {
                    Repo.Delete(e);

                }
                Repo.Dispose();
            }

        }

       

        [TestMethod()]
        public void GetAllTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddTest()
        {
          
                User user = new User
                {
                    UserName = "Demo",
                    Password = "Demo"
                };
                Repo.Add(user);
                var all = Repo.GetAll().ToList();
                bool count = all.Any();

                Assert.IsTrue(count);
            
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FindByIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DisposeTest()
        {
            Assert.Fail();
        }
    }
}
