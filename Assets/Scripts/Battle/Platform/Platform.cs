using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Platform : AbstractPlace<Platform>
{
    [SerializeField] 
    private Transform _centerOfTopBound;
    
    public Transform CenterOfTopBound => _centerOfTopBound;

    [SerializeField, ReadOnly]
    private PlatformObject _platformObject;

    public PlatformObject PlatformObject
    {
        get { return _platformObject; }
        set
        {
            if (value == null)
            {
                EmptyPlatform();
            }
            
            _platformObject = value;
            IsFree = false;
        }
    }

    [SerializeField, ReadOnly]
    private CollectableObject _collectableObject;
    public CollectableObject CollectableObject => _collectableObject;

    public void SetCollectableObject(CollectableObject collectableObject)
    {
        _collectableObject = collectableObject;
        _collectableObject.SetOnPlatform(this);
    }

    public void SetPlatformObject(PlatformObject platformObject)
    {
        // Set links on platform object and platform
        PlatformObject = platformObject;
        _platformObject.CurrentPlatform = this;
        
        // Remove this platform from list of free platforms
        PlatformMap.Instance.FreePlatforms.Remove(this);
        
        // Resolve picking collectable
        if (_collectableObject != null)
        {
            platformObject.CollectableController.Collect(_collectableObject);
            _collectableObject.Destroy();
            _collectableObject = null;
        }
    }

    public bool IsFree { get; private set; } = true;

    public void EmptyPlatform()
    {
        _platformObject = null;
        IsFree = true;
        PlatformMap.Instance.FreePlatforms.Add(this);
    }
    
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

    private void OnValidate()
    {   
        // Find CenterOfTopBound in children
        _centerOfTopBound = GameObjectUtils.GetChildrenWithTag(gameObject, TagEnum.PlatformTopCenter)?.transform;
        if (_centerOfTopBound == null)
        {
            Debug.LogError("Platform doesn't have CenterOfTopBound");
        }
    }

}
