using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsayeshMessenger.Core;
using Ninject;

namespace AsayeshMessenger.Core
{
    public static class IoC
    {
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        public static IUIManager UI => IoC.Get<IUIManager>();

        public static ApplicationViewModel Application => IoC.Get<ApplicationViewModel>();

        public static SettingsViewModel Settings => IoC.Get<SettingsViewModel>();

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }

        public static void Setup()
        {
            BindViewModels();
            
        }

        private static void BindViewModels()
        {
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
            Kernel.Bind<SettingsViewModel>().ToConstant(new SettingsViewModel());
        }
    }
}
