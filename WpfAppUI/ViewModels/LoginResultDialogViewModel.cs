using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using WpfAppUI.Commands;

namespace WpfAppUI.ViewModels
{
    public class LoginResultDialogViewModel
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public Brush TitleColor { get; set; }
        public ICommand CloseCommand { get; }

        public LoginResultDialogViewModel()
        {
            CloseCommand = new RelayCommand(CloseDialog);
        }

        private void CloseDialog(object parameter)
        {
            // Dialog'u kapatma işlemi
            if (parameter is MaterialDesignThemes.Wpf.DialogSession session)
            {
                session.Close();
            }
        }
    }
}
