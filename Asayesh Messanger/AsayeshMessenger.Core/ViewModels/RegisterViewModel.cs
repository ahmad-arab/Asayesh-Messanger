using System.Threading.Tasks;
using System.Windows.Input;

namespace Asayesh_Messanger.Core
{
    public class RegisterViewModel : BaseViewModel
    {
        #region Public properties
        public string Username { get; set; }
        public bool RegisterIsRunning { get; set; }
        #endregion

        #region Commands
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        #endregion

        #region Constructoer
        public RegisterViewModel()
        {
            RegisterCommand = new RelayCommand(async (parameter) => await RegisterAsync(parameter));
            LoginCommand = new RelayCommand(async (v) => await LoginAsync(new object()));
        }


        #endregion
        #region Methods
        public async Task RegisterAsync(object parameter)
        {
            await RunCommand(() => this.RegisterIsRunning, async () =>
            {
                await Task.Delay(5000);
                var username = this.Username;
                var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
            });


        }
        public async Task LoginAsync(object parameter)
        {
            //((WindowViewModel)(((MainWindow)(System.Windows.Application.Current.MainWindow)).DataContext)).CurrentPage = ApplicationPage.Register;
            //IoC.Get<ApplicationViewModel>().SideMenuVisible ^= true;

            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Login);
            await Task.Delay(1);
        }
        #endregion
    }
}