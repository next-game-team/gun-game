using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Platform : MonoBehaviour
{
    
    [SerializeField]
    private List<Platform> _neighborsList;

    [SerializeField]
    private List<Transform> _sidePointList;

    private bool _isEnabled = false;

    public List<Transform> SidePointList => _sidePointList;

    public void SetNeighbors(List<Platform> neighborsList)
    {
        if (neighborsList.Count > SidePointList.Count)
        {
            Debug.LogError("Platform has more neighbors than sides");
        }
        
        _neighborsList = neighborsList;
    }

    public void Enable()
    {
        _isEnabled = true;
    }
    
    public void Disable()
    {
        _isEnabled = false;
    }

    public bool IsEnabled()
    {
        return _isEnabled;
    }

    public bool HasDisabledNeighbor()
    {
        return _neighborsList.Any(neighbor => neighbor.IsEnabled() == false);
    }

    public Platform GetRandomDisabledPlatform()
    {
        var disabledNeighbors = _neighborsList.FindAll(neighbor => neighbor.IsEnabled() == false);

        if (disabledNeighbors.Count == 0)
        {
            Debug.LogWarning("Tries to get disabled platform from platform without disabled neighbor");
            return null;
        }

        return disabledNeighbors[Random.Range(0, disabledNeighbors.Count)];
    }
    
    protected void OnValidate()
    {
        _sidePointList = GetComponentsInChildren<Transform>().ToList();
        SidePointList.Remove(transform);
    }
}
