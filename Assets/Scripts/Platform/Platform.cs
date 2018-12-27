using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;

public class Platform : MonoBehaviour
{
    
    [SerializeField]
    private List<Platform> _neighborsList;

    [SerializeField]
    private List<Transform> _sidePointList;

    [SerializeField] 
    private Transform _centerOfTopBound;

    [SerializeField, ReadOnly]
    private PlatformObject _platformObject;

    public PlatformObject PlatformObject
    {
        get { return _platformObject; }
        private set
        {
            if (PlatformObject == null) throw new NoNullAllowedException();
            
            _platformObject = PlatformObject;
            IsFree = false;
        }
    }

    public bool IsFree { get; private set; } = true;

    public void EmptyPlatform()
    {
        _platformObject = null;
        IsFree = true;
    }

    public List<Transform> SidePointList => _sidePointList;
    
    public void SetNeighbors(List<Platform> neighborsList)
    {
        if (neighborsList.Count > SidePointList.Count)
        {
            Debug.LogError("Platform has more neighbors than sides");
        }
        
        _neighborsList = neighborsList;
    }
    
    public bool IsEnabled { get; private set; } = false;

    public Transform CenterOfTopBound => _centerOfTopBound;

    public void Enable()
    {
        IsEnabled = true;
    }
    
    public void Disable()
    {
        IsEnabled = false;
    }

    public bool HasDisabledNeighbor()
    {
        return _neighborsList.Any(neighbor => neighbor.IsEnabled == false);
    }

    public Platform GetRandomDisabledPlatform()
    {
        var disabledNeighbors = _neighborsList.FindAll(neighbor => neighbor.IsEnabled == false);

        if (disabledNeighbors.Count == 0)
        {
            Debug.LogWarning("Tries to get disabled platform from platform without disabled neighbor");
            return null;
        }

        return disabledNeighbors[Random.Range(0, disabledNeighbors.Count)];
    }

    private void Awake()
    {
        _centerOfTopBound = GameObjectUtils.GetChildrenWithTag(gameObject, TagEnum.PlatformTopCenter).transform;
    }

    protected void OnValidate()
    {
        _sidePointList = GetComponentsInChildren<Transform>().ToList();
        SidePointList.Remove(transform);
    }
}
