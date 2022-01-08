
using AsayeshMessenger.Core;
using System.Threading.Tasks;
using System.Windows;

namespace AsayeshMessenger
{
    public class UIManager : IUIManager
    {
        public Task ShowMessage(MessageBoxDialogViewModel viewModel)
        {
            return new DialogMessageBox().ShowDialog(viewModel);
        }
    }
}
