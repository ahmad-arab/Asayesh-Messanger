
using System.Windows.Input;

namespace AsayeshMessenger.Core
{
    /// <summary>
    ///
    /// </summary>
    public class SettingsViewModel: BaseViewModel
    {
        #region Public Properties
        public TextEntryViewModel Name { get; set; }

        public TextEntryViewModel Password { get; set; }

        public TextEntryViewModel Username { get; set; }

        public TextEntryViewModel Email { get; set; }

        #endregion

        #region Public Commands
        public ICommand CloseCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>

        public SettingsViewModel()
        {
            CloseCommand = new RelayCommand(Close);
            OpenCommand = new RelayCommand(Open);
        }

        #endregion

        #region Command Methods
        public void Close()
        {
            IoC.Application.SettingsMenuVisible = false;
        }
        public void Open()
        {
            IoC.Application.SettingsMenuVisible = true;
        }
        #endregion
    }
}
