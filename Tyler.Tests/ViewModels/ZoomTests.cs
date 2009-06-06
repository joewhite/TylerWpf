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
            var transform = Zoom.GetTransform(42);

            Assert.That(transform.ScaleX, Is.EqualTo(4.2));
            Assert.That(transform.ScaleY, Is.EqualTo(4.2));
        }
        [Test]
        public void Transform_WithZoomInLevel3_FitsFiveTiles()
        {
            Zoom.Level = 3;

            var transform = Zoom.GetTransform(42);

            Assert.That(transform.ScaleX, Is.EqualTo(8.4));
            Assert.That(transform.ScaleY, Is.EqualTo(8.4));
        }
        [Test]
        public void Transform_WithZoomOutLevel3_FitsTwentyTiles()
        {
            Zoom.Level = -3;

            var transform = Zoom.GetTransform(42);

            Assert.That(transform.ScaleX, Is.EqualTo(2.1));
            Assert.That(transform.ScaleY, Is.EqualTo(2.1));
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