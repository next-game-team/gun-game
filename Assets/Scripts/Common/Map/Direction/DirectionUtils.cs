using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class DirectionUtils
{
    // All directions list
    public static readonly List<DirectionEnum> directionList = Enum
        .GetValues(typeof(DirectionEnum))
        .Cast<DirectionEnum>()
        .ToList();
    
    public static readonly Dictionary<DirectionEnum, Vector2> vectorDirectionDictionary =
        new Dictionary<DirectionEnum, Vector2>
        {
            {DirectionEnum.LEFT, Vector2.left},
            {DirectionEnum.RIGHT, Vector2.right},
            {DirectionEnum.UP, Vector2.up},
            {DirectionEnum.DOWN, Vector2.down}
        }; 
    
    public static T FindNeighbor<T, TP>(T place,
                                        DirectionEnum direction,
                                        float raycastLength,
                                        LayerMask neighborLayerMask) where T : AbstractPlace<T, TP>
    {
        var sidePoint = place.SidePoints.DirectionDictionary[direction];
        var directionVector = vectorDirectionDictionary[direction];
        var hit = Physics2D.Raycast(sidePoint.position, directionVector, raycastLength, neighborLayerMask);
        return hit.transform != null ? hit.transform.gameObject.GetComponent<T>() : null;
    }

    public static DirectionEnum GetOppositeDirection(DirectionEnum direction)
    {
        switch (direction)
        {
            case DirectionEnum.LEFT :
                return DirectionEnum.RIGHT;
            case DirectionEnum.RIGHT :
                return DirectionEnum.LEFT;
            case DirectionEnum.UP :
                return DirectionEnum.DOWN;
            case DirectionEnum.DOWN :
                return DirectionEnum.UP;
            default:
                Debug.LogWarning("There is no opposition for NONE direction");
                return DirectionEnum.NONE;
        }
    }

    public static bool IsVerticalDirection(DirectionEnum direction)
    {
        return direction == DirectionEnum.UP || direction == DirectionEnum.DOWN;
    }
}