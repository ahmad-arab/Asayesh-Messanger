
using System.Windows;
using System.Windows.Controls;

namespace AsayeshMessenger
{
    public class PanelChiledMarginProperty: BaseAttachedProperty<PanelChiledMarginProperty,string>
    {
        public override void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var panel = d as Panel;

            panel.Loaded += (s, ee) =>
             {
                 foreach(FrameworkElement child in panel.Children)
                 {
                     child.Margin = (Thickness)new ThicknessConverter().ConvertFromString(e.NewValue as string);
                 }
             };
        }

    }
}
