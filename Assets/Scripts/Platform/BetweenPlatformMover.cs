using UnityEngine;

public static class BetweenPlatformMover
{
    public static bool MoveTo(PlatformObject platformObject, DirectionEnum directionEnum)
    {
        platformObject.CurrentPlatform.EmptyPlatform();
        var newPlatform = GetNeighborByDirection(platformObject.CurrentPlatform, directionEnum);
        if (newPlatform == null || !newPlatform.IsFree)
        {
            return false;
        }
        
        newPlatform.SetPlatformObject(platformObject);
        return true;
    }

    public static Platform GetNeighborByDirection(Platform platform, DirectionEnum directionEnum)
    {
        switch (directionEnum)
        {
            case DirectionEnum.LEFT:
                return platform.Neighbors.Left;
            case DirectionEnum.RIGHT:
                return platform.Neighbors.Right;
            case DirectionEnum.UP:
                return platform.Neighbors.Top;
            case DirectionEnum.DOWN:
                return platform.Neighbors.Bottom;
            default:
                return null;
        }
    }
}
