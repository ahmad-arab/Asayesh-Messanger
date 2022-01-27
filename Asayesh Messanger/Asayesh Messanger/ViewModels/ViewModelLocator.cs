using AsayeshMessenger.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayeshMessenger
{
    public class ViewModelLocator
    {
        public static ViewModelLocator Instance {  get; private set; } = new ViewModelLocator();

        public static ApplicationViewModel ApplicationViewModel => IoC.Application;

        public static SettingsViewModel SettingsViewModel => IoC.Settings;
    }
}
