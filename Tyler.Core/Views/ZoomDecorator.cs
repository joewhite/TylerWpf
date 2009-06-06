using System;
using System.Windows;
using System.Windows.Controls;
using Tyler.ViewModels;

namespace Tyler.Views
{
    public class ZoomDecorator : Decorator
    {
        public static readonly DependencyProperty ZoomProperty =
            DependencyProperty.Register("Zoom", typeof(Zoom), typeof(ZoomDecorator),
                                        new PropertyMetadata(ZoomChanged));

        public Zoom Zoom
        {
            get { return (Zoom) GetValue(ZoomProperty); }
            set { SetValue(ZoomProperty, value); }
        }

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            ZoomChild(arrangeSize);
            return base.ArrangeOverride(arrangeSize);
        }
        private static void ZoomChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var decorator = d as ZoomDecorator;
            if (decorator != null)
                decorator.ZoomChanged(e);
        }
        private void ZoomChanged(DependencyPropertyChangedEventArgs e)
        {
            var oldZoom = e.OldValue as Zoom;
            if (oldZoom != null)
                oldZoom.LevelChanged -= ZoomLevelChanged;

            var newZoom = e.NewValue as Zoom;
            if (newZoom != null)
                newZoom.LevelChanged += ZoomLevelChanged;
        }
        private void ZoomChild(Size arrangeSize)
        {
            var transformableChild = Child as FrameworkElement;
            if (transformableChild == null || Zoom == null)
                return;
            transformableChild.LayoutTransform = Zoom.GetTransform(arrangeSize.Height);
        }
        private void ZoomLevelChanged(object sender, EventArgs e)
        {
            ZoomChild(new Size(ActualWidth, ActualHeight));
        }
    }
}