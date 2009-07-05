using System.Windows.Input;

namespace Tyler.ViewModels
{
    public class InputCommand
    {
        public InputCommand(InputCommandType type)
        {
            Type = type;
        }

        public bool Handled { get; set; }
        public InputCommandType Type { get; private set; }

        public static InputCommand FromKeyInput(KeyEventArgs args)
        {
            return new InputCommand(TypeFromKeyInput(args));
        }
        private static InputCommandType TypeFromKeyInput(KeyEventArgs args)
        {
            switch (args.Key)
            {
                case Key.Up:
                case Key.NumPad8:
                    return InputCommandType.North;
                case Key.Down:
                case Key.NumPad2:
                    return InputCommandType.South;
                case Key.Left:
                case Key.NumPad4:
                    return InputCommandType.West;
                case Key.Right:
                case Key.NumPad6:
                    return InputCommandType.East;
                case Key.Space:
                case Key.Enter:
                case Key.Clear: // numpad 5 without NumLock
                case Key.NumPad5:
                case Key.X: // for discoverability, since dialogue Close button has an 'X' on it
                    return InputCommandType.Action;
                default:
                    return InputCommandType.None;
            }
        }
    }
}