
using System.Threading.Tasks;

namespace AsayeshMessenger.Core
{
    public interface IUIManager
    {
        Task ShowMessage(MessageBoxDialogViewModel viewModel);
    }
}
