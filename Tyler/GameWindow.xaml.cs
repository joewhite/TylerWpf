using System.Windows.Input;
using Tyler.ViewModels;
using Tyler.Views;

namespace Tyler
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow
    {
        public GameWindow()
        {
            InitializeComponent();
        }
        public GameWindow(DialogueView dialogueView)
        {
            InitializeComponent();
            layers.Children.Add(DialogueView = dialogueView);
        }

        private DialogueView DialogueView { get; set; }
        private Zoom Zoom
        {
            get { return (Zoom) FindResource("Zoom"); }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            var command = InputCommand.FromKeyInput(e);
            if (command.Type == InputCommandType.None)
                return;

            e.Handled = true; // this is a game key, not a WPF framework key
            if (DialogueView != null)
                DialogueView.ProcessInput(command);
            if (!command.Handled)
                mapView.ProcessInput(command);
        }
        private void ZoomIn_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            Zoom.ZoomIn();
        }
        private void ZoomOut_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            Zoom.ZoomOut();
        }
        private void ZoomReset_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            Zoom.Reset();
        }
    }
}