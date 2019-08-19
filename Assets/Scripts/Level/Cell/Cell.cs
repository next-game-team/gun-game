using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cell : AbstractPlace<Cell>
{
    [SerializeField, ReadOnly, Header("Info")] 
    private bool _isMain;
    
    [SerializeField, ReadOnly]
    private bool _isStart;
    
    [SerializeField, ReadOnly]
    private bool _isChecked;

    [SerializeField, ReadOnly] 
    private CellType _type = CellType.Empty;

    [SerializeField, ReadOnly] 
    private int _distance = int.MaxValue;
    
    [SerializeField, ReadOnly] 
    private Neighbors<GameObject> _lineNeighbors = new Neighbors<GameObject>();

    [SerializeField, Header("Configuration")]
    private SpriteRenderer _icon;
    
    [SerializeField, Range(0, 1)] 
    private float _generateProbability = 0.5f;
    
    public bool IsMain
    {
        get { return _isMain; }
        set { _isMain = value; }
    }
    
    public bool IsStart
    {
        get { return _isStart; }
        set { _isStart = value; }
    }
    
    public bool IsChecked
    {
        get { return _isChecked; }
        set { _isChecked = value; }
    }
    
    public CellType Type
    {
        get { return _type; }
        set { _type = value; }
    }
    
    public float GenerateProbability
    {
        get { return _generateProbability; }
        set { _generateProbability = value; }
    }

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

    private void OnValidate()
    {   
        // Find CenterOfTopBound in children
        _centerOfTopBound = GameObjectUtils.GetChildrenWithTag(gameObject, TagEnum.PlatformTopCenter)?.transform;
        if (_centerOfTopBound == null)
        {
            Debug.LogError("Platform doesn't have CenterOfTopBound");
        }
    }*/

    public void UpdateType(CellType type)
    {
        Type = type;
        _icon.sprite = CellTypeManager.Instance.TypeIconDictionary[type];
    }

    public List<DirectionEnum> GetFreeNeighborDirections()
    {
        var freeDirections = new List<DirectionEnum>();
        foreach (var pair in Neighbors.DirectionDictionary)
        {
            if (pair.Value == null)
            {
                freeDirections.Add(pair.Key);
            }
        }

        return freeDirections;
    }

    public bool HasNeighborWithType(CellType type)
    {
        return Neighbors.List().Any(neighbor => neighbor.Type == type);
    }
}
