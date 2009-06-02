using System.Windows.Controls;
using System.Windows.Input;

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
            switch (e.Key)
            {
                case Key.Left:
                    Canvas.SetLeft(hero, Canvas.GetLeft(hero) - 1);
                    e.Handled = true;
                    break;
                case Key.Right:
                    Canvas.SetLeft(hero, Canvas.GetLeft(hero) + 1);
                    e.Handled = true;
                    break;
                case Key.Up:
                    Canvas.SetTop(hero, Canvas.GetTop(hero) - 1);
                    e.Handled = true;
                    break;
                case Key.Down:
                    Canvas.SetTop(hero, Canvas.GetTop(hero) + 1);
                    e.Handled = true;
                    break;
            }
        }
        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Focus();
            e.Handled = true;
        }
    }
}