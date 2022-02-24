using AsayeshMessenger.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AsayeshMessenger
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ApplicationSetup();

            IoC.Logger.Log("This is Debug", LogLevel.Debug);
            IoC.Logger.Log("This is Verbose", LogLevel.Verbose);
            IoC.Logger.Log("This is Informative", LogLevel.Informative);
            IoC.Logger.Log("This is Warning", LogLevel.Warning);
            IoC.Logger.Log("This is Error", LogLevel.Error);
            IoC.Logger.Log("This is Success", LogLevel.Success);



            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        private void ApplicationSetup()
        {
            IoC.Setup();

            //Bind a UI Manager
            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());

            //Bind a Logger
            IoC.Kernel.Bind<ILogFactory>().ToConstant(new BaseLogFactory());
        }
    }
}
