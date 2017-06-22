using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public  class UserRepository
    {
        public User GetUser(string login)
        {
            using (TestEntities dbContext = new TestEntities())
            {
                var user =new User();
                try
                {
                    user = dbContext.Users.First(p => p.Login == login);
                }
                catch (Exception)
                {
                   // write to file logout.log
                }
                return user;
            }
                
        }
        public User GetUser(int id)
        {
            using (TestEntities dbContext = new TestEntities())
            {
                var user = new User();
                try
                {
                    user = dbContext.Users.First(p => p.Id==id);
                }
                catch (Exception)
                {
                    // write to file logout.log
                }
                return user;
            }

        }
        public int SaveUser(User user)
        {
            using (TestEntities dbContext = new TestEntities())
            {
                var ExistUser = new User();
                ExistUser = GetUser(user.Login);
                if (ExistUser.Id==0)
                {
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                    return 0;
                } else
                {
                    return -1;
                }
                
            }
        }
    }
}
