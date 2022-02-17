using System;
using System.Threading.Tasks;

namespace AsayeshMessenger.Core
{
    public class ChatMessageListItemImageAttachmentViewModel : BaseViewModel
    {
        #region Private members
        private string mThumbnailUrl;
        #endregion

        public string Title { get; set; }

        public string FileName { get; set; }

        public long FileSize { get; set; }

        public string ThumbnailUrl
        {
            get => mThumbnailUrl;

            set
            {
                if (value == mThumbnailUrl)
                    return;

                mThumbnailUrl = value;

                //TODO: Download the thumbnail from server

                Task.Delay(2000).ContinueWith(t => LocalFilePath = "/Images/Samples/123.jpg");
            }
        }

        public string LocalFilePath { get; set; }

        public bool ImageLoaded => LocalFilePath != null;
    }
}
