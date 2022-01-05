using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayeshMessenger.Core
{
    public class ChatAttachmentPopupMenuViewModel: BasePopupViewModel
    {
        public ChatAttachmentPopupMenuViewModel()
        {
            Content = new MenuViewModel() {
                Items = new List<MenuItemViewModel>
                {
                    new MenuItemViewModel { Text = "Attach File...", Icon = IconType.File, Type = MenuItemType.Header },
                    new MenuItemViewModel { Text = "From Computer", Icon = IconType.File },
                    new MenuItemViewModel { Text = "From Pictures", Icon = IconType.Picture },
                }
            };
        }
    }
}
