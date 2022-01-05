

using AsayeshMessenger.Core;
using System;

namespace AsayeshMessenger.Core
{
    public class ApplicationViewModel: BaseViewModel
    {
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Chat;

        public bool SideMenuVisible { get; set; } = true;

        internal void GoToPage(ApplicationPage page)
        {
            CurrentPage = page;

            SideMenuVisible = page == ApplicationPage.Chat;
        }
    }
}
