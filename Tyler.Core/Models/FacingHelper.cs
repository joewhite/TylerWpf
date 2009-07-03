namespace Tyler.Models
{
    public static class FacingHelper
    {
        public static int DeltaX(this Facing facing)
        {
            switch (facing)
            {
                case Facing.West:
                    return -1;
                case Facing.East:
                    return 1;
                default:
                    return 0;
            }
        }
        public static int DeltaY(this Facing facing)
        {
            switch (facing)
            {
                case Facing.North:
                    return -1;
                case Facing.South:
                    return 1;
                default:
                    return 0;
            }
        }
    }
}