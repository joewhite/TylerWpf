using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Tyler.Models;
using Tyler.ViewModels;

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
                default:
                    command.Handled = false;
                    break;
            }
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