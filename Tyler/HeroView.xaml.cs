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
        private Facing m_facing;

        public HeroView()
        {
            InitializeComponent();
            Spritesheet = (BitmapImage) FindResource("spritesheet");
            Facings = new Dictionary<Facing, CroppedBitmap>();
            Facing = Facing.South;
        }

        public Facing Facing
        {
            get { return m_facing; }
            set
            {
                m_facing = value;
                UpdateImage();
            }
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
        private void UpdateImage()
        {
            image.Source = GetImage(m_facing);
        }
    }
}