
using System;
using System.Windows;

namespace AsayeshMessenger
{
    public abstract class AnimateBaseProperty<Parent>: BaseAttachedProperty<Parent, bool>
        where Parent: BaseAttachedProperty<Parent, bool>, new()
    {
        #region Public Properties
        public bool FirstLoad { get; set; } = true;
        #endregion

        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            if (!(sender is FrameworkElement elemnt))
                return;

            if (sender.GetValue(ValueProperty) == value && !FirstLoad)
                return;

            if (FirstLoad)
            {
                RoutedEventHandler OnLoaded = null;
                OnLoaded = (ss, ee) =>
                {

                    elemnt.Loaded -= OnLoaded;

                    DoAnimation(elemnt, (bool)value);

                    FirstLoad = false;
                };

                elemnt.Loaded += OnLoaded;
            }
            else DoAnimation(elemnt, (bool)value);
        }

        protected virtual void DoAnimation(FrameworkElement elemnt, bool value) { }
    }

    public class AnimateSlideInFromLeftProperty: AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement elemnt, bool value)
        {
            if (value)
                await elemnt.SlideAndFadeInFromLeft(FirstLoad? 0 : 0.3f,KeepMargin:false);
            else
                await elemnt.SlideAndFadeOutToLeft(FirstLoad ? 0 : 0.3f, KeepMargin: false);
        }
    }

    public class AnimateSlideInFromBottomProperty : AnimateBaseProperty<AnimateSlideInFromBottomProperty>
    {
        protected override async void DoAnimation(FrameworkElement elemnt, bool value)
        {
            if (value)
                await elemnt.SlideAndFadeInFromBottom(FirstLoad ? 0 : 0.3f, KeepMargin: false);
            else
                await elemnt.SlideAndFadeOutToBottom(FirstLoad ? 0 : 0.3f, KeepMargin: false);
        }
    }
}
