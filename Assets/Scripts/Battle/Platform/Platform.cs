using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Platform : AbstractPlace<Platform, PlatformType>
{
    //[SerializeField] TODO is not using currently
    private Transform _centerOfTopBound;
    
    public Transform CenterOfTopBound => _centerOfTopBound;

    public bool IsEnabled { get; private set; } = false;

    public void Enable()
    {
        IsEnabled = true;
    }
    
    public void Disable()
    {
        IsEnabled = false;
    }

    public bool HasFreeEnabledNeighbor()
    {
        return Neighbors.List().Any(neighbor => neighbor.IsFree);
    }

    public Platform GetRandomFreeNeighbor()
    {
        // Find all free neighbors
        var freeNeighbors = Neighbors.List().FindAll(neighbor => neighbor.IsFree);
        
        // Return null if there is no any free neighbors or return random free neighbor
        return RandomUtils.GetRandomObjectFromList(freeNeighbors);
    }

    public DirectionEnum GetRandomFreeNeighborDirection()
    {
        var freeDirections = new List<DirectionEnum>();
        foreach (var pair in Neighbors.DirectionDictionary)
        {
            if (pair.Value != null && pair.Value.IsFree)
            {
                freeDirections.Add(pair.Key);
            }
        }
        
        return freeDirections.Count == 0 ? DirectionEnum.NONE : RandomUtils.GetRandomObjectFromList(freeDirections);
    }

    /*private void OnValidate()
    {   
        // Find CenterOfTopBound in children
        _centerOfTopBound = GameObjectUtils.GetChildrenWithTag(gameObject, TagEnum.PlatformTopCenter)?.transform;
        if (_centerOfTopBound == null)
        {
            Debug.LogError("Platform doesn't have CenterOfTopBound");
        }
    }*/

    public override void HandleNewObject()
    {
        // Remove this platform from list of free platforms
        PlatformMap.Instance.FreePlatforms.Remove(this);
    }

    public override void HandleEmpty()
    {
        PlatformMap.Instance.FreePlatforms.Add(this);
    }
    
    public override void SetType(PlatformType type)
    {
        Type = type;
        Icon.sprite = PlatformTypeManager.Instance.TypeIconDictionary[type];
    }

    public override bool HasEmptyType()
    {
        return Type == PlatformType.Empty;
    }
}
