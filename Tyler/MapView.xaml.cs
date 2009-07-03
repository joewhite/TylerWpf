using System.Windows;
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

        private bool IsPassable(int x, int y)
        {
            return (x >= 1 && x <= 17 && y >= 3 && y <= 9) ||
                   treeTrunk.Data.FillContains(new Point(x + .5, y + .5));
        }
        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            switch (e.Key)
            {
                case Key.Left:
                    Walk(Facing.West);
                    break;
                case Key.Right:
                    Walk(Facing.East);
                    break;
                case Key.Up:
                    Walk(Facing.North);
                    break;
                case Key.Down:
                    Walk(Facing.South);
                    break;
                default:
                    e.Handled = false;
                    return;
            }
        }
        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Focus();
            e.Handled = true;
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