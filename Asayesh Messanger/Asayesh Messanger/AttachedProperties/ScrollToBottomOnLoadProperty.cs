
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace AsayeshMessenger
{

    public class ScrollToBottomOnLoadProperty:BaseAttachedProperty<ScrollToBottomOnLoadProperty,bool>
    {
        public override void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(d))
                return;

            if (!(d is ScrollViewer control))
                return;
            control.DataContextChanged -= Control_DataContextChanged;
            control.DataContextChanged += Control_DataContextChanged;
        }

        private void Control_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            (sender as ScrollViewer).ScrollToBottom();
        }
    }
}
