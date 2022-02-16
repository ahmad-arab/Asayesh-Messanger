
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AsayeshMessenger
{
    /// <summary>
    /// Creats a clipping region from the parent <see cref="Border"/> <see cref="CornerRadius"/>
    /// </summary>
    public class ClipFromBorderProperty: BaseAttachedProperty<ClipFromBorderProperty, bool>
    {

        #region Private members

        private RoutedEventHandler mBorder_Loaded;
        private SizeChangedEventHandler mBorder_SizeShanged;

        #endregion

        public override void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var Self = (d as FrameworkElement);

            if(!(Self.Parent is Border border))
            {
                Debugger.Break();
                return;
            }

            mBorder_Loaded = (s1, e1) => Border_OnChange(s1, e1, Self);

            mBorder_SizeShanged = (s1, e1) => Border_OnChange(s1, e1,Self);

            if((bool)e.NewValue)
            {
                border.Loaded += mBorder_Loaded;
                border.SizeChanged+= mBorder_SizeShanged;
            }
            else
            {
                border.Loaded -= mBorder_Loaded;
                border.SizeChanged -= mBorder_SizeShanged;
            }

        }

        private void Border_OnChange(object sender, RoutedEventArgs e, FrameworkElement child)
        {
            var border = (Border)sender;

            if (border.ActualWidth == 0 && border.ActualHeight == 0)
                return;

            var rect = new RectangleGeometry();
            rect.RadiusX = rect.RadiusY = Math.Max(0, border.CornerRadius.TopLeft - (border.BorderThickness.Left * 0.5));

            rect.Rect = new Rect(child.RenderSize);

            child.Clip = rect;
        }
    }
}
