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
            SetFacing(Facing.South);
        }

        private Dictionary<Facing, CroppedBitmap> Facings { get; set; }
        private BitmapImage Spritesheet { get; set; }

        private CroppedBitmap GetImage(Facing facing)
        {
            if (Spritesheet == null)
                return null;
            if (!Facings.ContainsKey(facing))
            {
                var rect = new Int32Rect(240, ((int) facing)*320, 240, 320);
                Facings[facing] = new CroppedBitmap(Spritesheet, rect);
            }
            return Facings[facing];
        }
        public void SetFacing(Facing value)
        {
            image.Source = GetImage(value);
        }
    }
}