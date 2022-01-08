using AsayeshMessenger.Core;
using System.Windows;

namespace AsayeshMessenger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ApplicationViewModel ApplicationViewModel => new ApplicationViewModel();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new WindowViewModel(this);
        }

        private void appwindow_Activated(object sender, System.EventArgs e)
        {
            (DataContext as WindowViewModel).DimmableOverLayVisible = false;
        }

        private void appwindow_Deactivated(object sender, System.EventArgs e)
        {
            (DataContext as WindowViewModel).DimmableOverLayVisible = true;

        }
    }
}
