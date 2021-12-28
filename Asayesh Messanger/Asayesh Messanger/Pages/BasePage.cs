

using System.Windows.Controls;
using System.Windows;
using System.Threading.Tasks;
using System;
using System.Windows.Media.Animation;
using Asayesh_Messanger.Core;

namespace Asayesh_Messanger
{
    public class BasePage:Page
    {
        #region Public properties
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        public float SlideSeconds { get; set; } = 0.4f;

        public bool ShouldAnimateOut { get; set; }

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
            if (ShouldAnimateOut)
                await AnimateOut();
            else
                await AnimateIn();
        }

        private async Task AnimateIn()
        {
            if (this.PageLoadAnimation == PageAnimation.None) return;

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInFromRight(this.SlideSeconds);
                    break;
            }
        }
        public async Task AnimateOut()
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

    public class BasePage<VM>: BasePage
        where VM: BaseViewModel, new()
    {
        #region Private members
        private VM mViewModel { get; set; }
        #endregion
        #region Public Properies
        
        public VM ViewModel
        {
            get { return mViewModel; }
            set 
            {
                if (mViewModel == value) return;

                mViewModel = value;

                this.DataContext = mViewModel;
            }
        }

        #endregion

        #region Constructor
        public BasePage(): base()
        {
            this.ViewModel = new VM();
        }
        #endregion
        
    }
}
