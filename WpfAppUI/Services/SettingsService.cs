using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppUI.Models;

namespace WpfAppUI.Services
{
    public class SettingsService
    {
        private const string SettingsFile = "userPreferences.json";
        public UserPreferences LoadSettings()
        {
            if (File.Exists(SettingsFile))
            {
                string json = File.ReadAllText(SettingsFile);
                return JsonConvert.DeserializeObject<UserPreferences>(json);
            }

            // Varsayılan değerler
            return new UserPreferences { IsDarkTheme = true };
        }

        public void SaveSettings(UserPreferences preferences)
        {
            string json = JsonConvert.SerializeObject(preferences, Formatting.Indented);
            File.WriteAllText(SettingsFile, json);
        }
    }
}
