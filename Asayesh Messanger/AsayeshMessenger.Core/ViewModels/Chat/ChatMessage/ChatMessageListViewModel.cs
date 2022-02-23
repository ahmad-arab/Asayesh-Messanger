using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace AsayeshMessenger.Core
{
    public class ChatMessageListViewModel : BaseViewModel
    {
        #region Protected properties
        protected string mLastSearchText;
        protected string mSearchText;
        protected ObservableCollection<ChatMessageListItemViewModel> mItems;
        protected bool mSearchIsOpen;

        #endregion

        #region Public Properties
        public ObservableCollection<ChatMessageListItemViewModel> Items
        {
            get => mItems;
            set
            {
                if (mItems == value)
                    return;

                mItems = value;

                //Update the filteredItems list
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(mItems);
            }
        }

        public ObservableCollection<ChatMessageListItemViewModel> FilteredItems { get; set;  }

        /// <summary>
        /// The Title of this chat list
        /// </summary>
        public string DisplayTitle { get; set; }

        public bool AttachmentMenuVisibile { get; set; } = false;
        public bool AnyPopupVisibil => AttachmentMenuVisibile;

        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }

        public string PendingMessageText { get; set; }

        public string SearchText
        {
            get => mSearchText;
            set
            {
                //check if the value is the same
                if (mSearchText == value)
                    return;

                //Update the search text
                mSearchText = value;

                if (String.IsNullOrEmpty(SearchText))
                    Search();
            }
        }

        public bool SearchIsOpen
        {
            get => mSearchIsOpen;
            set
            {
                if (mSearchIsOpen == value)
                    return;

                mSearchIsOpen = value;

                if (!mSearchIsOpen)
                    SearchText = string.Empty;
            }
        }
        #endregion

        #region Commands
        public ICommand AttachmentButtonCommand { get; set; }
        public ICommand PopupClickawayCommand { get; set; }
        public ICommand SendCommand { get; set; }

        /// <summary>
        /// The command for when the user wants to search
        /// </summary>
        public ICommand SearchCommand { get; set; }

        /// <summary>
        /// The command for when the user wants to open search dialog
        /// </summary>
        public ICommand OpenSearchCommand { get; set; }

        /// <summary>
        /// The command for when the user wants to close search dialog
        /// </summary>
        public ICommand CloseSearchCommand { get; set; }

        /// <summary>
        /// The command for when the user wants to cleare search text
        /// </summary>
        public ICommand CleareSearchCommand { get; set; }
        #endregion

        #region Constructor
        public ChatMessageListViewModel()
        {
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);
            PopupClickawayCommand = new RelayCommand(PopupClickaway);
            SendCommand = new RelayCommand(Send);

            SearchCommand = new RelayCommand(Search);
            OpenSearchCommand = new RelayCommand(OpenSearch);
            CloseSearchCommand = new RelayCommand(CloseSearch);
            CleareSearchCommand = new RelayCommand(CleareSearch);


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
            //Don't send a blank message
            //TODO: allow blank message when there is an attachment
            if (String.IsNullOrEmpty(PendingMessageText))
                return;

            if (Items == null)
                Items = new ObservableCollection<ChatMessageListItemViewModel>();
            if (FilteredItems == null)
                Items = new ObservableCollection<ChatMessageListItemViewModel>();

            var message = new ChatMessageListItemViewModel
            {
                Initials = "AA",
                 Message = PendingMessageText,
                  SenderName ="Ahmad Arab",
                   MessageSentTime = DateTime.Now,
                   SentByMe = true,
                    NewItem = true
            };

            Items.Add(message);
            FilteredItems.Add(message);

            PendingMessageText = string.Empty;
        }

        public void Search()
        {
            if ((String.IsNullOrEmpty(mLastSearchText) && String.IsNullOrEmpty(SearchText)) ||
                string.Equals(mLastSearchText, SearchText))
                return;

            if(String.IsNullOrEmpty(SearchText) || Items==null || Items.Count <=0)
            {
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(Items);

                mLastSearchText = SearchText;

                return;
            }

            //TODO: Make a more efficiant search
            FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(Items.Where(item =>
                                  item.Message.ToLower().Contains(SearchText.ToLower())));

            //Set Last Search
            mLastSearchText = SearchText;
        }

        public void CleareSearch()
        {
            if (!String.IsNullOrEmpty(SearchText))
                SearchText = string.Empty;
            else
                SearchIsOpen = false;
        }

        public void CloseSearch() => SearchIsOpen = false;

        public void OpenSearch() => SearchIsOpen = true;
        #endregion
    }
}
