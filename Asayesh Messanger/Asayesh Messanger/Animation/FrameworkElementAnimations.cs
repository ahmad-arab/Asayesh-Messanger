using System;

using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
namespace AsayeshMessenger
{
    public static class FrameworkElementAnimations
    {      
        #region From/To Left
        public static async Task SlideAndFadeInFromLeft(this FrameworkElement element, float seconds=0.3f, bool KeepMargin = true, double width = 0)
        {
            var sb = new Storyboard();
            sb.AddSlideFromLeft(seconds, width == 0 ? element.ActualWidth : width, KeepMargin: KeepMargin);
            sb.AddFadeIn(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);
        }

        public static async Task SlideAndFadeOutToLeft(this FrameworkElement element, float seconds = 0.3f, bool KeepMargin = true, double width = 0)
        {
            var sb = new Storyboard();
            sb.AddSlideToLeft(seconds, width == 0 ? element.ActualWidth : width, KeepMargin: KeepMargin);
            sb.AddFadeOut(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);
        }
        #endregion

        #region From/To Right
        public static async Task SlideAndFadeInFromRight(this FrameworkElement element, float seconds = 0.3f, bool KeepMargin = true, double width = 0)
        {
            var sb = new Storyboard();
            sb.AddSlideFromRight(seconds, width == 0 ? element.ActualWidth : width, KeepMargin: KeepMargin);
            sb.AddFadeIn(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);
        }
        public static async Task SlideAndFadeOutToRight(this FrameworkElement element, float seconds = 0.3f, bool KeepMargin = true, double width = 0)
        {
            var sb = new Storyboard();
            sb.AddSlideToRight(seconds, width == 0 ? element.ActualWidth : width, KeepMargin: KeepMargin);
            sb.AddFadeOut(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);
        }
        #endregion

        #region From/To Bottom
        public static async Task SlideAndFadeInFromBottom(this FrameworkElement element, float seconds = 0.3f, bool KeepMargin = true, double height = 0)
        {
            var sb = new Storyboard();
            sb.AddSlideFromBottom(seconds, height == 0 ? element.ActualHeight : height, KeepMargin: KeepMargin);
            sb.AddFadeIn(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);
        }

        public static async Task SlideAndFadeOutToBottom(this FrameworkElement element, float seconds = 0.3f, bool KeepMargin = true, double height = 0)
        {
            var sb = new Storyboard();
            sb.AddSlideToBottom(seconds, height == 0 ? element.ActualHeight : height, KeepMargin: KeepMargin);
            sb.AddFadeOut(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);
        }
        #endregion
    }
}
