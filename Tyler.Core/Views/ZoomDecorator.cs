using System.Windows;
using System.Windows.Controls;
using Tyler.ViewModels;

namespace Tyler.Views
{
    public class ZoomDecorator : Decorator
    {
        private readonly Zoom m_zoom = new Zoom();

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            var transformableChild = Child as FrameworkElement;
            if (transformableChild != null)
                transformableChild.LayoutTransform = m_zoom.GetTransform(arrangeSize.Height);
            return base.ArrangeOverride(arrangeSize);
        }
    }
}