using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField, ReadOnly] 
    private PlatformNeighbors _neighbors;

    public PlatformNeighbors Neighbors
    {
        get { return _neighbors; }
        set { _neighbors = value; }
    }

    [SerializeField] private PlatformSidePoints _sidePoints = new PlatformSidePoints();

    public PlatformSidePoints SidePoints => _sidePoints;

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
            if (PlatformObject == null)
            {
                _platformObject = null;
                IsFree = true;
            }
            
            _platformObject = PlatformObject;
            _platformObject.CurrentPlatform = this;
            IsFree = false;
        }
    }

    public bool IsFree { get; private set; } = true;

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
        return _neighbors.List.Any(neighbor => neighbor.IsEnabled && neighbor.IsFree);
    }

    public Platform GetRandomFreePlatform()
    {
        // Find all free neighbors
        var freeNeighbors = _neighbors.List.FindAll(neighbor => neighbor.IsEnabled && neighbor.IsFree);
        
        // Return null if there is no any free neighbors or return random free neighbor
        return freeNeighbors.Count == 0 ? null : freeNeighbors[Random.Range(0, freeNeighbors.Count)];
    }

    private void OnValidate()
    {   
        // Find CenterOfTopBound in children
        _centerOfTopBound = GameObjectUtils.GetChildrenWithTag(gameObject, TagEnum.PlatformTopCenter).transform;
        if (_centerOfTopBound == null)
        {
            Debug.LogError("Platform doesn't have CenterOfTopBound");
        }
    }

}
