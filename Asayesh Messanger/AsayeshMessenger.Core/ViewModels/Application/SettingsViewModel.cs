
using System;
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

        public PasswordEntryViewModel Password { get; set; }

        public TextEntryViewModel Username { get; set; }

        public TextEntryViewModel Email { get; set; }

        public string LogoutButtonText { get; set; }

        #endregion

        #region Public Commands
        public ICommand CloseCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public ICommand ClearUserDataCommand { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>

        public SettingsViewModel()
        {
            CloseCommand = new RelayCommand(Close);
            OpenCommand = new RelayCommand(Open);
            LogoutCommand = new RelayCommand(Logout);
            ClearUserDataCommand = new RelayCommand(ClearUserData);

            //TODO: Remove the shit below
            Name = new TextEntryViewModel { Label = "Name", OriginalText = $"Ahmad Arab{DateTime.Now.ToLocalTime()}" };
            Username = new TextEntryViewModel { Label = "Username", OriginalText = "Ahmad" };
            Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "*******" };
            Email = new TextEntryViewModel { Label = "Email", OriginalText = "ahmadarab45521@gmail.com" };

            LogoutButtonText = "Logout";
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
        public void Logout()
        {
            //TODO: Confirm that user actualy wants to logout
            ClearUserData();

            IoC.Application.GoToPage(ApplicationPage.Login);
        }

        private void ClearUserData()
        {
            Name = null;
            Username = null;
            Password = null;
            Email = null;
        }
        #endregion
    }
}
