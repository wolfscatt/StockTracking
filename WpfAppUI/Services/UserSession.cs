using Entities.Concrete;
using WpfAppUI.Models;

namespace WpfAppUI.Services
{
    public class UserSession
    {
        private static UserSession _instance;
        public static UserSession Instance => _instance ??= new UserSession();

        public User CurrentUser { get; private set; }
        public void SetUser(User user)
        {
            CurrentUser = user;
        }
        public void Clear() => CurrentUser = null;

        private UserSession() { }
    }
   
}
