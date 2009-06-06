using System.Windows;
using System.Windows.Controls;
using Tyler.ViewModels;

namespace Tyler.Views
{
    public class ZoomDecorator : Decorator
    {
        protected override Size ArrangeOverride(Size arrangeSize)
        {
            ZoomChild(arrangeSize);
            return base.ArrangeOverride(arrangeSize);
        }
        private void ZoomChild(Size arrangeSize)
        {
            var zoom = (Zoom) TryFindResource(typeof(Zoom));
            if (zoom == null)
                return;
            var transformableChild = Child as FrameworkElement;
            if (transformableChild == null)
                return;
            transformableChild.LayoutTransform = zoom.GetTransform(arrangeSize.Height);
        }
    }
}