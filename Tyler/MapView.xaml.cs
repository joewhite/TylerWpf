using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Tyler.Models;
using Tyler.ViewModels;

namespace Tyler
{
    /// <summary>
    /// Interaction logic for MapView.xaml
    /// </summary>
    public partial class MapView
    {
        private readonly IDialogueService m_dialogueService = new NullDialogueService();

        public MapView()
        {
            InitializeComponent();
        }
        public MapView(IDialogueService dialogueService)
        {
            InitializeComponent();
            m_dialogueService = dialogueService;
        }

        public IDialogueService DialogueService
        {
            get { return m_dialogueService; }
        }

        private bool IsPassable(int x, int y)
        {
            return (x >= 1 && x <= 17 && y >= 3 && y <= 9) ||
                   treeTrunk.Data.FillContains(new Point(x + .5, y + .5));
        }
        public void ProcessInput(InputCommand command)
        {
            command.Handled = true;
            switch (command.Type)
            {
                case InputCommandType.West:
                    Walk(Facing.West);
                    break;
                case InputCommandType.East:
                    Walk(Facing.East);
                    break;
                case InputCommandType.North:
                    Walk(Facing.North);
                    break;
                case InputCommandType.South:
                    Walk(Facing.South);
                    break;
                case InputCommandType.Action:
                    Talk();
                    break;
                default:
                    command.Handled = false;
                    break;
            }
        }
        private void Talk()
        {
            var document = new FlowDocument();

            var firstParagraph = new Paragraph();
            firstParagraph.Inlines.Add(new Run("Captain: ") {Foreground = Brushes.Gold});
            firstParagraph.Inlines.Add(
                new Run("Arr! Me poor kitty be stuck in this big, scary tree!"));
            document.Blocks.Add(firstParagraph);

            var secondParagraph = new Paragraph();
            secondParagraph.Inlines.Add(new Run("Hero: ") {Foreground = Brushes.Gold});
            secondParagraph.Inlines.Add(new Run("...?"));
            document.Blocks.Add(secondParagraph);

            var thirdParagraph = new Paragraph();
            thirdParagraph.Inlines.Add(new Run("Captain: ") {Foreground = Brushes.Gold});
            thirdParagraph.Inlines.Add(new Run("Well, I be afraid o' heights!"));
            document.Blocks.Add(thirdParagraph);

            var fourthParagraph = new Paragraph {BreakPageBefore = true};
            fourthParagraph.Inlines.Add(new Run("Captain: ") {Foreground = Brushes.Gold});
            fourthParagraph.Inlines.Add(new Run("But if ye tell anyone, I'll slit yer gullet."));
            document.Blocks.Add(fourthParagraph);

            DialogueService.Show(document);
        }
        private void Walk(Facing facing)
        {
            hero.Facing = facing;
            var newLeft = Canvas.GetLeft(hero) + facing.DeltaX();
            var newTop = Canvas.GetTop(hero) + facing.DeltaY();
            if (!IsPassable((int) newLeft, (int) newTop))
                return;
            Canvas.SetLeft(hero, newLeft);
            Canvas.SetTop(hero, newTop);
            Canvas.SetLeft(scroller, -newLeft);
            Canvas.SetTop(scroller, -newTop);
        }
    }
}