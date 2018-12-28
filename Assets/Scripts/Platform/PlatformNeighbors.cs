using System.Collections.Generic;

public class PlatformNeighbors
{
    public PlatformNeighbors(Platform left, Platform right, Platform top, Platform bottom)
    {
        Left = left;
        Right = right;
        Top = top;
        Bottom = bottom;
        List = new List<Platform>() {Left, Right, Top, Bottom};
    }

    public Platform Left { get; set; }
    public Platform Right { get; set; }
    public Platform Top { get; set; }
    public Platform Bottom { get; set; }

    public List<Platform> List { get; }
}