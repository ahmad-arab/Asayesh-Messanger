using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Asayesh_Messanger
{
    public class BaseAttachedProperty<Parent, Property>
        where Parent: new()
    {
        #region Public Events
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };
        public event Action<DependencyObject, object> ValueUpdated = (sender, value) => { };
        #endregion
        #region Public Properties
        public static Parent Instance { get; private set; } = new Parent();
        #endregion

        #region Attached Properties Defenitions 
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached("Value", 
                typeof(Property), 
                typeof(BaseAttachedProperty<Parent, Property>), 
                new UIPropertyMetadata(
                    default(Property),
                    new PropertyChangedCallback(OnValuePropertyChanged),
                    new CoerceValueCallback(OnValuePropertyUpdated)
                    ));

        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueChanged(d, e);
            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueChanged(d, e);
        }
        private static object OnValuePropertyUpdated(DependencyObject d, object value)
        {
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueUpdated(d, value);
            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueUpdated(d, value);
            return value;
        }

        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);
        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty,value);
        #endregion

        #region Events Methods
        public virtual void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) { }
        public virtual void OnValueUpdated(DependencyObject d, object value) { }
        #endregion
    }
}
