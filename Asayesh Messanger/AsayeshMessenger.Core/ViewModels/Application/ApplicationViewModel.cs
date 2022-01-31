

using AsayeshMessenger.Core;
using System;

namespace AsayeshMessenger.Core
{
    public class ApplicationViewModel: BaseViewModel
    {
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Chat;

        public BaseViewModel CurrentPageViewModel { get; set; }

        public bool SideMenuVisible { get; set; } = true;

        public bool SettingsMenuVisible { get; set; } = false;

        public void GoToPage(ApplicationPage page, BaseViewModel viewModel = null)
        {
            SettingsMenuVisible = false;

            CurrentPageViewModel = viewModel;

            CurrentPage = page;

            OnPropertyChanged(nameof(CurrentPage));

            SideMenuVisible = page == ApplicationPage.Chat;
        }
    }
}
