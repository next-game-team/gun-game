using System;
using UnityEngine;

[Serializable]
public abstract class AbstractPlace<T> : MonoBehaviour where T : AbstractPlace<T>
{

    [SerializeField] private SidePoints _sidePoints;
    
    [SerializeField, ReadOnly]
    private CollectableObject _collectableObject;
    public CollectableObject CollectableObject
    {
        get { return _collectableObject; }
        set { _collectableObject = value; }
    }

    public void SetCollectableObject(CollectableObject collectableObject)
    {
        _collectableObject = collectableObject;
        _collectableObject.SetOnPlace(transform);
    }

    [SerializeField, ReadOnly]
    private PlaceObject<T> _currentObject;

    public PlaceObject<T> CurrentObject
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
    
    public void SetCurrentObject(PlaceObject<T> placeObject)
    {
        // Set links on platform object and platform
        CurrentObject = placeObject;
        HandleNewObject(placeObject);
    }

    public abstract void HandleNewObject(PlaceObject<T> placeObject);

    public SidePoints SidePoints => _sidePoints;
    
    public bool IsFree { get; private set; } = true;
    
    private Neighbors<T> _neighbors = new Neighbors<T>();
    
    public Neighbors<T> Neighbors
    {
        get { return _neighbors; }
        set { _neighbors = value; }
    }
    
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