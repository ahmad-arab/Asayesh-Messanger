
using AsayeshMessenger.Core;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AsayeshMessenger
{
    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {
        public ApplicationPage CurrentPage
        {
            get { return (ApplicationPage)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentPage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(ApplicationPage), 
                typeof(PageHost), new UIPropertyMetadata(default(ApplicationPage), null,CurrentPagePropertChanged));

        public BaseViewModel CurrentPageViewModel
        {
            get { return (BaseViewModel)GetValue(CurrentPageViewModelProperty); }
            set { SetValue(CurrentPageViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentPage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPageViewModelProperty =
            DependencyProperty.Register(nameof(CurrentPageViewModel), typeof(BaseViewModel),
                typeof(PageHost), new UIPropertyMetadata());

        #region Constructor

        public PageHost()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this))
                NewPage.Content = IoC.Application.CurrentPage.ToBasePage();
        }

        #endregion

        #region Property Changed Events
        private static object CurrentPagePropertChanged(DependencyObject d, object e)
        {
            var currentPage = (ApplicationPage)d.GetValue(CurrentPageProperty);
            var currentPageViewModel = d.GetValue(CurrentPageViewModelProperty);

            var newPageFrame = (d as PageHost).NewPage;
            var oldPageFrame = (d as PageHost).OldPage;

            if (newPageFrame.Content is BasePage page &&
                page.ToApplicationPage() == currentPage)
            {
                page.ViewModelObject = currentPageViewModel;

                return e;
            }

            
            // Store the current page content as the old page
            var oldPageContent = newPageFrame.Content;

            // Remove current page from new page frame
            newPageFrame.Content = null;

            // Move the previous page into the old page frame
            oldPageFrame.Content = oldPageContent;

            // Animate out previous page when the Loaded event fires
            // right after this call due to moving frames
            if (oldPageContent is BasePage oldPage)
            {
                // Tell old page to animate out
                oldPage.ShouldAnimateOut = true;

                // Once it is done, remove it
                Task.Delay((int)(oldPage.SlideSeconds * 1000)).ContinueWith((t) =>
                {
                    // Remove old page
                    Application.Current.Dispatcher.Invoke(() => oldPageFrame.Content = null);
                });
            }

            // Set the new page content
            newPageFrame.Content = currentPage.ToBasePage(currentPageViewModel);

            return e;
        }
        #endregion
    }
}
