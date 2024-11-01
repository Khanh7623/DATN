using IndividualBlog.Data;
using IndividualBlog.Models;
using IndividualBlog.Models.ViewModel;
using IndividualBlog.Utilties.Common;
using IndividualBlog.Utilties.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualBlog.Services.UserService
{
    public class ServiceUser : IServiceUser
    {
        private readonly ApplicationDbContext context;
        public ServiceUser(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> AddUser(User user)
        {
            if(user == null)
            {
                return 0;
            }
            user.Password = CommonFunction.CreateMD5(user.Password);
            await context.Users.AddAsync(user);
            if(await context.SaveChangesAsync() > 0)
            {
                return 1;
            }
            return 0;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var result = await context.Users.FindAsync(id);
            if(result == null)
            {
                return false;
            }
            context.Users.Remove(result);
           if( await context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public List<User> GetAll()
        {
           return context.Users.OrderByDescending(x => x.Id).ToList();
        }

        public User GetById(int id)
        {
            return  context.Users.FirstOrDefault(x => x.Id == id);
        }

        public async Task<User> Login(ViewModelLogin user)
        {
            string password = CommonFunction.CreateMD5(user.Password);
            var result  = await context.Users.FirstOrDefaultAsync(x=>x.Email==user.Email && x.Password==password && x.Status==EUserStatus.Active);
            if( result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<int> Register(ViewModelRegisterUser user)
        {
            var checkEmail = context.Users.FirstOrDefaultAsync(x => x.Email == user.Email);
            if( checkEmail == null) // nếu email trống
            {
                return -1;
            }
            User newUser = new User()
            {
                FirtName = user.FirtName,
                LastName = user.LastName,
                Email = user.Email,
                Password = CommonFunction.CreateMD5(user.Password),
                Created_At = DateTime.Now,
                Updated_At = DateTime.Now,
                Role = Utilties.Enum.EUserRole.Member,

            };
            context.Users.Add(newUser);
            if( await context.SaveChangesAsync()>0)
            {
                return 1;
            }
            return 0;
        }

        public async Task<int> UpdateUser(User user, int id)
        {
            if (user == null && !UserExists(id))
            {
                return 0;
            }
            var oldUser = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (!string.IsNullOrEmpty(user.Password))
            {
                user.Password = CommonFunction.CreateMD5(user.Password);
            }
            if (!string.IsNullOrEmpty(user.Email))
            {
                user.Email = oldUser.Email;
            }


            user.Created_At = oldUser.Created_At;
            user.Password = oldUser.Password;
            user.Updated_At = System.DateTime.Now;
            context.ChangeTracker.Clear();
            context.Users.Update(user);
            if (await context.SaveChangesAsync() > 0)
            {
                return 1;
            }
            return 0;
        }
        public bool UserExists(int id)
        {
            return context.Users.Any(e => e.Id == id);
        }
    }
}
