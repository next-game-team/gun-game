using UnityEngine;

public class Cell : AbstractPlace<Cell>
{
    [SerializeField, ReadOnly] private int _distance;
    
    [SerializeField, ReadOnly] 
    private Neighbors<GameObject> _lineNeighbors = new Neighbors<GameObject>();

    public Neighbors<GameObject> LineNeighbors
    {
        get { return _lineNeighbors; }
        set { _lineNeighbors = value; }
    }

    public int Distance
    {
        get { return _distance; }
        set { _distance = value; }
    }

    /*[SerializeField] 
    private Transform _centerOfTopBound;
    
    public Transform CenterOfTopBound => _centerOfTopBound; */

    /*[SerializeField, ReadOnly]
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

    public void SetPlatformObject(PlatformObject platformObject)
    {
        // Set links on platform object and platform
        PlatformObject = platformObject;
        _platformObject.CurrentPlatform = this;
    }

    //public bool IsFree { get; private set; } = true;

    public void EmptyPlatform()
    {
        _platformObject = null;
        IsFree = true;
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
        return _neighbors.List.Any(neighbor => neighbor.IsFree);
    }

    public Platform GetRandomFreeNeighbor()
    {
        // Find all free neighbors
        var freeNeighbors = _neighbors.List.FindAll(neighbor => neighbor.IsFree);
        
        // Return null if there is no any free neighbors or return random free neighbor
        return RandomUtils.GetRandomObjectFromList(freeNeighbors);
    }

    public DirectionEnum GetRandomFreeNeighborDirection()
    {
        var freeDirections = new List<DirectionEnum>();
        foreach (var pair in _neighbors.DirectionDictionary)
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
    }*/
}
