using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Asayesh_Messanger
{
    public class MonitorPasswordProperty: BaseAttachedProperty<MonitorPasswordProperty,bool>
    {
        public override void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var password = d as PasswordBox;

            if (password == null) return;

            password.PasswordChanged -= Password_PasswordChanged;
            if ((bool)e.NewValue)
            {
                HasTextProperty.SetValue(password);
                password.PasswordChanged += Password_PasswordChanged;
            }
        }

        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            HasTextProperty.SetValue((DependencyObject)sender);
        }
    }
    public class HasTextProperty: BaseAttachedProperty<HasTextProperty, bool> 
    { 
        public static void SetValue(DependencyObject sender)
        {
            HasTextProperty.SetValue(sender, (sender as PasswordBox).SecurePassword.Length > 0);
        }
    }
}
