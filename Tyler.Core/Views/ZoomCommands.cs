using System.Windows.Input;

namespace Tyler.Views
{
    public class ZoomCommands
    {
        public static readonly RoutedUICommand ZoomResetCommand =
            new RoutedUICommand("Reset Zoom", "ZoomResetCommand", typeof(ZoomCommands),
                                new InputGestureCollection
                                    {new KeyGesture(Key.D0, ModifierKeys.Control)});

        public static readonly RoutedUICommand ZoomInCommand =
            new RoutedUICommand("Zoom In", "ZoomInCommand", typeof(ZoomCommands),
                                new InputGestureCollection
                                    {
                                        new KeyGesture(Key.Add, ModifierKeys.Control),
                                        new KeyGesture(Key.OemPlus, ModifierKeys.Control),
                                    });

        public static readonly RoutedUICommand ZoomOutCommand =
            new RoutedUICommand("Zoom Out", "ZoomOutCommand", typeof(ZoomCommands),
                                new InputGestureCollection
                                    {
                                        new KeyGesture(Key.Subtract, ModifierKeys.Control),
                                        new KeyGesture(Key.OemMinus, ModifierKeys.Control),
                                    });
    }
}