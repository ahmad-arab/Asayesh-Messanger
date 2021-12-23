

using System.Windows.Controls;
using System.Windows;
using System.Threading.Tasks;
using System;
using System.Windows.Media.Animation;

namespace Asayesh_Messanger
{
    public class BasePage: Page
    {
        #region Public Properies
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        public float SlideSeconds { get; set; } = 0.8f;
        #endregion

        #region Constructor
        public BasePage()
        {
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;
            this.Loaded += BasePage_Loaded;
        }
        #endregion
        #region Animiation Load/Unload

        private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await AnimateIn();
        }

        private async Task AnimateIn()
        {
            if (this.PageLoadAnimation == PageAnimation.None) return;

            switch(this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInFromRight(this.SlideSeconds);
                    break;
            }
        }
        private async Task AnimateOut()
        {
            if (this.PageUnloadAnimation == PageAnimation.None) return;

            switch (this.PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:
                    await this.SlideAndFadeOutToLeft(this.SlideSeconds);
                    break;
            }
        }
        #endregion
    }
}
