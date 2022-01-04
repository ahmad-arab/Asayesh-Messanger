using System.Collections.Generic;
using System.Windows.Input;

namespace Asayesh_Messanger.Core
{
    public class ChatMessageListViewModel : BaseViewModel
    {
        #region Public Properties
        public List<ChatMessageListItemViewModel> Items { get; set; }
        public bool AttachmentMenuVisibile { get; set; } = false;
        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }
        #endregion

        #region Commands
        public ICommand AttachmentButtonCommand { get; set; }
        #endregion

        #region Constructor
        public ChatMessageListViewModel()
        {
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);
            AttachmentMenu = new ChatAttachmentPopupMenuViewModel();
        }
        #endregion

        #region Command Methods
        private void AttachmentButton()
        {
            AttachmentMenuVisibile ^= true;
        }
        #endregion
    }
}
