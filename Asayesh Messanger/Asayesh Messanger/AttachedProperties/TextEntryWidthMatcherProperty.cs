
using System;
using System.Windows;
using System.Windows.Controls;

namespace AsayeshMessenger
{

    public class TextEntryWidthMatcherProperty: BaseAttachedProperty<TextEntryWidthMatcherProperty, bool>
    {
        public override void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var panel = d as Panel;

            SetWidth(panel);

            RoutedEventHandler onLoaded = null;

            onLoaded = (s, ee) =>
            {
                panel.Loaded -= onLoaded;

                SetWidth(panel);

                foreach (FrameworkElement child in panel.Children)
                {
                    if (!(child is TextEntryControl control))
                        continue;

                    control.Label.SizeChanged += (ss, eee) =>
                      {
                          SetWidth(panel);
                      };


                }
            };
            panel.Loaded += onLoaded;
        }

        private void SetWidth(Panel panel)
        {
            var maxSize = 0d;

            foreach(var child in panel.Children)
            {
                if (!(child is TextEntryControl control))
                    continue;


                maxSize = Math.Max(maxSize, control.Label.RenderSize.Width + control.Label.Margin.Left + control.Label.Margin.Right);
            }
            var gridLength = (GridLength)new GridLengthConverter().ConvertFromString(maxSize.ToString());
            foreach (var child in panel.Children)
            {
                if (!(child is TextEntryControl control))
                    continue;

                control.LabelWidth = gridLength;
            }
        }
    }
}
