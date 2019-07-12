using System;

[Serializable]
public class PlatformNeighbors : Neighbors<Platform>
{
    public PlatformNeighbors()
    {
    }

    public PlatformNeighbors(Platform left, Platform right, Platform top, Platform bottom) : base(left, right, top, bottom)
    {
    }
}