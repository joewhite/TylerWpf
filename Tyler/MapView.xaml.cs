using System.Windows.Controls;
using System.Windows.Input;
using Tyler.Models;

namespace Tyler
{
    /// <summary>
    /// Interaction logic for MapView.xaml
    /// </summary>
    public partial class MapView
    {
        public MapView()
        {
            InitializeComponent();
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            var oldLeft = Canvas.GetLeft(hero);
            var oldTop = Canvas.GetTop(hero);
            var newLeft = oldLeft;
            var newTop = oldTop;
            switch (e.Key)
            {
                case Key.Left:
                    newLeft = oldLeft - 1;
                    hero.SetFacing(Facing.West);
                    break;
                case Key.Right:
                    newLeft = oldLeft + 1;
                    hero.SetFacing(Facing.East);
                    break;
                case Key.Up:
                    newTop = oldTop - 1;
                    hero.SetFacing(Facing.North);
                    break;
                case Key.Down:
                    newTop = oldTop + 1;
                    hero.SetFacing(Facing.South);
                    break;
            }
            if (newLeft == oldLeft && newTop == oldTop)
                return;
            Canvas.SetLeft(hero, newLeft);
            Canvas.SetTop(hero, newTop);
            Canvas.SetLeft(scroller, -newLeft);
            Canvas.SetTop(scroller, -newTop);
            e.Handled = true;
        }
        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Focus();
            e.Handled = true;
        }
    }
}