using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asayesh_Messanger.Core
{
    public class ChatAttachmentPopupMenuDesignModel: ChatAttachmentPopupMenuViewModel
    {
        #region Singelton
        public static ChatAttachmentPopupMenuViewModel Instance => new ChatAttachmentPopupMenuViewModel();
        #endregion
        #region Constructor
        public ChatAttachmentPopupMenuDesignModel()
        {
        }
        #endregion
    }
}
