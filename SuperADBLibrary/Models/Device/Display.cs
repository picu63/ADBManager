namespace SuperAdbLibrary.Models
{
    public class Display
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Density { get; set; }
        public float AspectRatio { get { return (float)Height / Width; } set { AspectRatio = value; } }
    }
}