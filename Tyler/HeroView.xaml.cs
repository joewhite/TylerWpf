using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;
using Tyler.Models;

namespace Tyler
{
    /// <summary>
    /// Interaction logic for HeroView.xaml
    /// </summary>
    public partial class HeroView
    {
        public HeroView()
        {
            InitializeComponent();
            Spritesheet = (BitmapImage) FindResource("spritesheet");
            Facings = new Dictionary<Facing, CroppedBitmap>();
            Facings[Facing.North] = new CroppedBitmap(Spritesheet, new Int32Rect(240, 0, 240, 320));
            Facings[Facing.East] = new CroppedBitmap(Spritesheet, new Int32Rect(240, 320, 240, 320));
            Facings[Facing.South] = new CroppedBitmap(Spritesheet, new Int32Rect(240, 640, 240, 320));
            Facings[Facing.West] = new CroppedBitmap(Spritesheet, new Int32Rect(240, 960, 240, 320));
            SetFacing(Facing.South);
        }

        private Dictionary<Facing, CroppedBitmap> Facings { get; set; }
        private BitmapImage Spritesheet { get; set; }

        public void SetFacing(Facing value)
        {
            image.Source = Facings[value];
        }
    }
}