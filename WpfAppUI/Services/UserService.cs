using Autofac;
using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WpfAppUI.DependencyResolvers;
using WpfAppUI.Models;
using WpfAppUI.Services.Interfaces;

namespace WpfAppUI.Services
{
    public class UserService : IUserServiceFrontEnd
    {
        private readonly IUserService _userService;
        private User _currentUser;

        public UserService()
        {
            _userService = IocContainer.Container.Resolve<IUserService>();
        }
       
        public bool IsLoggedIn => _currentUser != null;
        public User CurrentUser => _currentUser;

        public User Authenticate(string username, string password)
        {
            List<User> users = _userService.GetAllUser().Data ?? new List<User>();
            return users.FirstOrDefault(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                u.Password == password
            ) ;
        }

        public void Login(User user)
        {
            _currentUser = user;
            UserSession.Instance.SetUser(user);
        }

        public void Logout()
        {
            _currentUser = null;
            UserSession.Instance.Clear();
        }
    }

}
