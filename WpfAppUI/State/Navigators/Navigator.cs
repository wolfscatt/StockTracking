using System.Windows.Input;
using WpfAppUI.Commands;
using WpfAppUI.ViewModels;

namespace WpfAppUI.State.Navigators
{
    public class Navigator : INavigator
    {
        public ViewModelBase CurrentViewModel { get; set; }

        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);
    }
}
