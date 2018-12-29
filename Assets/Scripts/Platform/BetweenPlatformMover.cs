using UnityEngine;

public class BetweenPlatformMover
{
    public static void MoveTo(PlatformObject platformObject, DirectionEnum directionEnum)
    {
        platformObject.CurrentPlatform.EmptyPlatform();
        var newPlatform = GetNeighborByDirection(platformObject.CurrentPlatform, directionEnum);
        if (newPlatform == null)
        {
            Debug.LogError("Move to wrong direction");
        }
        
        newPlatform.PlatformObject = platformObject;
        platformObject.transform.position = newPlatform.CenterOfTopBound.position
                                            + platformObject.VectorFromBottomToCenter;
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
