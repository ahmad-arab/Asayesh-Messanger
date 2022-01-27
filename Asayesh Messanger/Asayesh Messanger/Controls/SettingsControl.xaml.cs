
using AsayeshMessenger.Core;
using System.Windows.Controls;

namespace AsayeshMessenger
{
    /// <summary>
    /// Interaction logic for SettingsControl.xaml
    /// </summary>
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();

            DataContext = IoC.Settings;
        }
    }
}
