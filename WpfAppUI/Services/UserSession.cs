using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppUI.Models;

namespace WpfAppUI.Services
{
    public class UserSession
    {
        private static UserSession _instance;
        public static UserSession Instance => _instance ??= new UserSession();

        public User CurrentUser { get; set; }

        private UserSession() { }
    }
}
