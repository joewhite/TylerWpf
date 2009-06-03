using System;
using System.Windows.Media;

namespace Tyler.ViewModels
{
    public class Zoom
    {
        private const int TilesVisibleAtDefaultZoom = 10;

        public int Level { get; set; }

        public ScaleTransform GetTransform(double clientHeight)
        {
            var relativeScale = clientHeight/Math.Pow(2, Level/3.0);
            var requestedScale = relativeScale/TilesVisibleAtDefaultZoom;
            var actualScale = Math.Max(requestedScale, 2);
            return new ScaleTransform(actualScale, actualScale);
        }
        public void Reset()
        {
            Level = 0;
        }
        public void ZoomIn()
        {
            ++Level;
        }
        public void ZoomOut()
        {
            --Level;
        }
    }
}