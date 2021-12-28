
using System.Windows;
using System.Windows.Controls;

namespace Asayesh_Messanger
{
    public class NoFrameHistory: BaseAttachedProperty<NoFrameHistory,bool>
    {
        public override void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var frame = (d as Frame);

            frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            frame.Navigated += (ss, ee) => ((Frame)ss).NavigationService.RemoveBackEntry();
        }
    }
}
