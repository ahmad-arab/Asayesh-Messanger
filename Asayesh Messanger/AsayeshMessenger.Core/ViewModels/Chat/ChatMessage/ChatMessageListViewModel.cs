using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AsayeshMessenger.Core
{
    public class ChatMessageListViewModel : BaseViewModel
    {
        #region Public Properties
        public ObservableCollection<ChatMessageListItemViewModel> Items { get; set; }

        public bool AttachmentMenuVisibile { get; set; } = false;
        public bool AnyPopupVisibil => AttachmentMenuVisibile;

        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }

        public string PendingMessageText { get; set; }
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
        public void Send()
        {
            if (Items == null)
                Items = new ObservableCollection<ChatMessageListItemViewModel>();

            Items.Add(new ChatMessageListItemViewModel
            {
                Initials = "AA",
                 Message = PendingMessageText,
                  SenderName ="Ahmad Arab",
                   MessageSentTime = DateTime.Now,
                   SentByMe = true,
                    NewItem = true
            });

            PendingMessageText = string.Empty;
        }
        #endregion
    }
}
