using EpiConnectAPI.Core.Model;
using EpiConnectAPI.Core.ViewModel;

namespace EpiConnectAPI.Data.Repository.Interfaces {
    public interface IUserRepository {
        //Task<User> Login(UserRequestView userRequest);
        Task<User> Register();
        Task<User> GetUserByEmail(string email);
    }
}
