using System;

using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
namespace Asayesh_Messanger
{
    public static class FrameworkElementAnimations
    {
        public static async Task SlideAndFadeInFromRight(this FrameworkElement element, float seconds = 0.3f,bool KeepMargin = true)
        {
            var sb = new Storyboard();
            sb.AddSlideFromRight(seconds, element.ActualWidth, KeepMargin:KeepMargin);
            sb.AddFadeIn(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);
        }
        public static async Task SlideAndFadeInFromLeft(this FrameworkElement element, float seconds=0.3f, bool KeepMargin = true)
        {
            var sb = new Storyboard();
            sb.AddSlideFromLeft(seconds, element.ActualWidth, KeepMargin: KeepMargin);
            sb.AddFadeIn(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);
        }

        public static async Task SlideAndFadeOutToLeft(this FrameworkElement element, float seconds = 0.3f, bool KeepMargin = true)
        {
            var sb = new Storyboard();
            sb.AddSlideToLeft(seconds, element.ActualWidth, KeepMargin: KeepMargin);
            sb.AddFadeOut(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);
        }

        public static async Task SlideAndFadeOutToRight(this FrameworkElement element, float seconds = 0.3f, bool KeepMargin = true)
        {
            var sb = new Storyboard();
            sb.AddSlideToRight(seconds, element.ActualWidth, KeepMargin: KeepMargin);
            sb.AddFadeOut(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);
        }
    }
}
