using Entities.Concrete;
using WpfAppUI.Models;

namespace WpfAppUI.Services.Interfaces
{
    public interface IUserServiceFrontEnd
    {
        User Authenticate(string username, string password);
        void Login(User user);
        void Logout();
        bool IsLoggedIn { get; }
        User CurrentUser { get; }
    }
}