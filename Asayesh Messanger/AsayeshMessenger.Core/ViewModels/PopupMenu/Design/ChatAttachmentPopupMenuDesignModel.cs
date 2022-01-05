using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayeshMessenger.Core
{
    public class ChatAttachmentPopupMenuDesignModel: ChatAttachmentPopupMenuViewModel
    {
        #region Singelton
        public static ChatAttachmentPopupMenuDesignModel Instance => new ChatAttachmentPopupMenuDesignModel();
        #endregion
        #region Constructor
        public ChatAttachmentPopupMenuDesignModel()
        {
        }
        #endregion
    }
}
