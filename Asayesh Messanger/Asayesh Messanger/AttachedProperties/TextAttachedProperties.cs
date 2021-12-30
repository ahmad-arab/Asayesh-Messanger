
using System.Windows;
using System.Windows.Controls;

namespace Asayesh_Messanger
{
    public class IsFocusedProperty : BaseAttachedProperty<IsFocusedProperty, bool>
    {
        public override void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is Control control))
                return;

            control.Loaded += (ss, ee) => control.Focus();
        }
    }
}
