using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppUI.UserControls.Dialogs;

namespace WpfAppUI.Services
{
    public static class DialogService
    {
        public static async Task<bool> ShowConfirmation(string message, string hostName = "RootDialog")
        {
            var dialog = new ConfirmDialog
            {
                Message = message
            };

            var result = await DialogHost.Show(dialog, hostName);
            return result?.ToString()?.ToLower() == "true";
        }
        public static async Task ShowInfo(string message, string hostName = "RootDialog")
        {
            var dialog = new InfoDialog
            {
                Message = message
            };

            await DialogHost.Show(dialog, hostName);
        }
    }
}
