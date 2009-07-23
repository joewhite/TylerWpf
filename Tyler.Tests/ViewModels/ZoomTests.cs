using NUnit.Framework;

namespace Tyler.ViewModels
{
    [TestFixture]
    public class ZoomTests
    {
        private Zoom Zoom { get; set; }

        [SetUp]
        public void SetUp()
        {
            Zoom = new Zoom();
        }

        [Test]
        public void Level_ByDefault_IsZero()
        {
            Assert.That(Zoom.Level, Is.EqualTo(0));
        }
        [Test]
        public void ZoomIn_IncreasesLevel()
        {
            Zoom.ZoomIn();
            Zoom.ZoomIn();

            Assert.That(Zoom.Level, Is.EqualTo(2));
        }
        [Test]
        public void ZoomOut_DecreasesLevel()
        {
            Zoom.ZoomOut();
            Zoom.ZoomOut();

            Assert.That(Zoom.Level, Is.EqualTo(-2));
        }
        [Test]
        public void Reset_SetsLevelToZero()
        {
            Zoom.Level = 3;

            Zoom.Reset();

            Assert.That(Zoom.Level, Is.EqualTo(0));
        }
        [Test]
        public void Transform_ByDefault_FitsTenTiles()
        {
            var transform = Zoom.GetTransform(420);

            Assert.That(transform.ScaleX, Is.EqualTo(42));
            Assert.That(transform.ScaleY, Is.EqualTo(42));
        }
        [Test]
        public void Transform_WithZoomInLevel3_FitsFiveTiles()
        {
            Zoom.Level = 3;

            var transform = Zoom.GetTransform(420);

            Assert.That(transform.ScaleX, Is.EqualTo(84));
            Assert.That(transform.ScaleY, Is.EqualTo(84));
        }
        [Test]
        public void Transform_WithZoomOutLevel3_FitsTwentyTiles()
        {
            Zoom.Level = -3;

            var transform = Zoom.GetTransform(420);

            Assert.That(transform.ScaleX, Is.EqualTo(21));
            Assert.That(transform.ScaleY, Is.EqualTo(21));
        }
        [Test]
        public void Transform_IsRoundedToOnePixelIncrements()
        {
            var transform = Zoom.GetTransform(58);

            Assert.That(transform.ScaleX, Is.EqualTo(6.0));
            Assert.That(transform.ScaleY, Is.EqualTo(6.0));
        }
        [Test]
        public void Transform_DoesNotGoBelowTwoPixelsPerTile()
        {
            Zoom.Level = -9;

            var transform = Zoom.GetTransform(42);

            Assert.That(transform.ScaleX, Is.EqualTo(2));
            Assert.That(transform.ScaleY, Is.EqualTo(2));
        }
    }
}