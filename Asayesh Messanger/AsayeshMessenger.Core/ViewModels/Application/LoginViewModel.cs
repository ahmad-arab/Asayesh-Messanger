
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AsayeshMessenger.Core
{
    public class LoginViewModel: BaseViewModel
    {
        #region Public properties
        public string Username { get; set; }
        public bool LoginIsRunning { get; set; }
        #endregion

        #region Commands
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        #endregion

        #region Constructoer
        public LoginViewModel()
        {
            LoginCommand = new ParametrizedRelayCommand(async (parameter) => await LoginAsync(parameter));
            RegisterCommand = new RelayCommand(async () => await RegisterAsync());
        }


        #endregion
        #region Methods
        public async Task LoginAsync(object parameter)
        {
            await RunCommand(() => this.LoginIsRunning, async () =>
              {
                  await Task.Delay(1000);

                  IoC.Settings.Name = new TextEntryViewModel { Label = "Name", OriginalText = $"Ahmad Arab{DateTime.Now.ToLocalTime()}" };
                  IoC.Settings.Username = new TextEntryViewModel { Label = "Username", OriginalText = "Ahmad" };
                  IoC.Settings.Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "*******" };
                  IoC.Settings.Email = new TextEntryViewModel { Label = "Email", OriginalText = "ahmadarab45521@gmail.com" };

                  var username = this.Username;
                  var pass = (parameter as IHavePassword).SecurePassword.Unsecure();

                  IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Chat);
              });

            
        }
        public async Task RegisterAsync()
        {
            //((WindowViewModel)(((MainWindow)(System.Windows.Application.Current.MainWindow)).DataContext)).CurrentPage = ApplicationPage.Register;
            //IoC.Get<ApplicationViewModel>().SideMenuVisible ^= true;

            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Register);
            await Task.Delay(1);
        }
        #endregion
    }
}
