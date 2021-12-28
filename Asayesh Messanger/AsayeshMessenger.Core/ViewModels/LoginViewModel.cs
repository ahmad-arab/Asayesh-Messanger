
using System.Threading.Tasks;
using System.Windows.Input;

namespace Asayesh_Messanger.Core
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
            LoginCommand = new RelayCommand(async (parameter) => await LoginAsync(parameter));
            RegisterCommand = new RelayCommand(async (v) => await RegisterAsync(new object()));
        }


        #endregion
        #region Methods
        public async Task LoginAsync(object parameter)
        {
            await RunCommand(() => this.LoginIsRunning, async () =>
              {
                  await Task.Delay(1000);
                  var username = this.Username;
                  var pass = (parameter as IHavePassword).SecurePassword.Unsecure();

                  IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Chat);
              });

            
        }
        public async Task RegisterAsync(object parameter)
        {
            //((WindowViewModel)(((MainWindow)(System.Windows.Application.Current.MainWindow)).DataContext)).CurrentPage = ApplicationPage.Register;
            //IoC.Get<ApplicationViewModel>().SideMenuVisible ^= true;

            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Register);
            await Task.Delay(1);
        }
        #endregion
    }
}
