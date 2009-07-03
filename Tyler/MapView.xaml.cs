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
                    Walk(Facing.West, -1, 0);
                    break;
                case Key.Right:
                    Walk(Facing.East, 1, 0);
                    break;
                case Key.Up:
                    Walk(Facing.North, 0, -1);
                    break;
                case Key.Down:
                    Walk(Facing.South, 0, 1);
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
        private void Walk(Facing facing, int deltaX, int deltaY)
        {
            hero.Facing = facing;
            var newLeft = Canvas.GetLeft(hero) + deltaX;
            var newTop = Canvas.GetTop(hero) + deltaY;
            if (!IsPassable((int) newLeft, (int) newTop))
                return;
            Canvas.SetLeft(hero, newLeft);
            Canvas.SetTop(hero, newTop);
            Canvas.SetLeft(scroller, -newLeft);
            Canvas.SetTop(scroller, -newTop);
        }
    }
}