namespace Nekman.Core.Utilities
{
    public readonly struct Size
    {
        public float Width { get; }
        public float Height { get; }

        public Size(float width, float height)
        {
            Width = width;
            Height = height;
        }
    }
}
