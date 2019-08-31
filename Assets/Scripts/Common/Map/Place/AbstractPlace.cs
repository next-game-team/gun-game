using System;
using UnityEngine;

[Serializable]
public abstract class AbstractPlace<T, TP> : MonoBehaviour where T : AbstractPlace<T, TP>
{
    [SerializeField, ReadOnly] private TP _type;

    [SerializeField, ReadOnly]
    private PlaceObject<T, TP> _currentObject;
    
    [SerializeField]
    private SpriteRenderer _icon;
    
    [SerializeField] private SidePoints _sidePoints;

    public PlaceObject<T, TP> CurrentObject
    {
        get { return _currentObject; }
        set
        {
            if (value == null)
            {
                Empty();
            }
            
            _currentObject = value;
            IsFree = false;
        }
    }
    
    public void SetCurrentObject(PlaceObject<T, TP> placeObject)
    {
        // Set links on platform object and platform
        CurrentObject = placeObject;
        CurrentObject.ResolveEntering();
        HandleNewObject();
    }

    public abstract void HandleNewObject();

    public SidePoints SidePoints => _sidePoints;
    
    public bool IsFree { get; private set; } = true;
    
    private Neighbors<T> _neighbors = new Neighbors<T>();
    
    public Neighbors<T> Neighbors
    {
        get { return _neighbors; }
        set { _neighbors = value; }
    }

    public TP Type
    {
        get { return _type; }
        set { _type = value; }
    }

    public SpriteRenderer Icon => _icon;

    public abstract void SetType(TP type);

    public abstract bool HasEmptyType();

    public void Empty()
    {
        _currentObject = null;
        IsFree = true;
        HandleEmpty();
    }

    public abstract void HandleEmpty();

    private void Awake()
    {
        _sidePoints.Init();
    }
}