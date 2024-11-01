using IndividualBlog.Models;
using IndividualBlog.Models.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IndividualBlog.Services.UserService
{
    public interface IServiceUser
    {
        List<User> GetAll();
        User GetById(int id);
        Task<int> AddUser(User user);
        Task<int> UpdateUser(User user, int id);
        Task<bool> DeleteUser(int id);
        Task<User> Login(ViewModelLogin user);
        Task<int> Register(ViewModelRegisterUser user);
        bool UserExists(int id);
    }
}
