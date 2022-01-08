using System.Collections.Generic;
using System.Windows.Input;

namespace AsayeshMessenger.Core
{
    public class ChatMessageListViewModel : BaseViewModel
    {
        #region Public Properties
        public List<ChatMessageListItemViewModel> Items { get; set; }

        public bool AttachmentMenuVisibile { get; set; } = false;
        public bool AnyPopupVisibil => AttachmentMenuVisibile;

        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }
        #endregion

        #region Commands
        public ICommand AttachmentButtonCommand { get; set; }
        public ICommand PopupClickawayCommand { get; set; }
        public ICommand SendCommand { get; set; }
        #endregion

        #region Constructor
        public ChatMessageListViewModel()
        {
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);
            PopupClickawayCommand = new RelayCommand(PopupClickaway);
            SendCommand = new RelayCommand(Send);

            AttachmentMenu = new ChatAttachmentPopupMenuViewModel();
        }
        #endregion

        #region Command Methods
        private void AttachmentButton()
        {
            AttachmentMenuVisibile ^= true;
        }

        private void PopupClickaway()
        {
            AttachmentMenuVisibile = false;
        }
        private void Send()
        {
            IoC.UI.ShowMessage(new MessageBoxDialogViewModel
            {
                Title = "Sending a message",
                Message = "Hi There I'm using Whatsup",
                OkText = "OK"
            });
        }
        #endregion
    }
}
