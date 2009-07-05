using System.Windows;
using Tyler.ViewModels;

namespace Tyler.Views
{
    /// <summary>
    /// Interaction logic for DialogueView.xaml
    /// </summary>
    public partial class DialogueView
    {
        public DialogueView()
        {
            InitializeComponent();
        }

        public void ProcessInput(InputCommand command)
        {
            if (Visibility != Visibility.Visible)
                return;

            command.Handled = true; // don't let anything through to the Map
            switch (command.Type)
            {
                case InputCommandType.North:
                    pages.PreviousPage();
                    break;
                case InputCommandType.South:
                case InputCommandType.Action:
                    if (pages.CanGoToNextPage)
                        pages.NextPage();
                    else
                        Visibility = Visibility.Collapsed;
                    break;
            }
        }
    }
}