using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppUI.Models;

namespace WpfAppUI.Services
{
    public class UserService
    {
        private List<User> _users = new List<User>
        {
            new User { Username = "admin", Password = "admin", FullName = "Admin User", Email = "admin@example.com" },
            new User { Username = "user1", Password = "1234", FullName = "User One", Email = "user1@example.com" }
        };

        public User Authenticate(string username, string password)
        {
            return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public void UpdateUser(User updatedUser)
        {
            // Burada veritabanına kaydedebilirsiniz.
            // Bu örnekte UserSession güncelleniyor.
            UserSession.Instance.CurrentUser = updatedUser;
        }
    }
}
