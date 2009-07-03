using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Tyler.Models;

namespace Tyler
{
    /// <summary>
    /// Interaction logic for SpriteView.xaml
    /// </summary>
    public partial class SpriteView
    {
        public static readonly DependencyProperty UriProperty =
            DependencyProperty.Register("Uri", typeof(Uri), typeof(SpriteView),
                                        new PropertyMetadata(UriChanged));

        private Facing m_facing;

        public SpriteView()
        {
            InitializeComponent();
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
        public Uri Uri
        {
            get { return (Uri) GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }

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
        private void UriChanged()
        {
            Spritesheet = new BitmapImage(Uri) {BaseUri = BaseUriHelper.GetBaseUri(this)};
            Facings.Clear();
            UpdateImage();
        }
        private static void UriChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((SpriteView) d).UriChanged();
        }
    }
}