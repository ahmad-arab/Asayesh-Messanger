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

            IoC.Logger.Log("Application Starting...", LogLevel.Debug);

            IoC.Task.Run(() =>
            {
                throw new ArgumentNullException("oooops");
            });

            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        private void ApplicationSetup()
        {
            IoC.Setup();

            //Bind a Logger
            IoC.Kernel.Bind<ILogFactory>().ToConstant(new BaseLogFactory(new[] {

                // TODO: Add application settings so we can set/edit a log location
                new FileLogger("log.txt")

            }));

            //Bind a TaskManager
            IoC.Kernel.Bind<ITaskManager>().ToConstant(new TaskManager());

            //Bind a FileManager
            IoC.Kernel.Bind<IFileManager>().ToConstant(new FileManager());

            //Bind a UI Manager
            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());
        }
    }
}
