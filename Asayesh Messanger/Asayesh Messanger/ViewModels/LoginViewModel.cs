using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Asayesh_Messanger
{
    public class LoginViewModel: BaseViewModel
    {
        #region Public properties
        public string Username { get; set; }
        public bool LoginIsRunning { get; set; }
        #endregion

        #region Commands
        public ICommand LoginCommand { get; set; }

        #endregion

        #region Constructoer
        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(async (parameter) => await Login(parameter));
        }


        #endregion
        #region Methods
        public async Task Login(object parameter)
        {
            await RunCommand(() => this.LoginIsRunning, async () =>
              {
                  await Task.Delay(5000);
                  var username = this.Username;
                  var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
              });

            
        }
        #endregion
    }
}
