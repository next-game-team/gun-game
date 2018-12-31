using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformMap : MonoBehaviour
{

    [SerializeField] 
    private List<List<Platform>> _platforms;

    [SerializeField, ReadOnly] 
    private int _rowCount;
    [SerializeField, ReadOnly] 
    private int _columnCount;

    private PlatformNeighborsFinder _neighborsFinder;
    
    public List<List<Platform>> Platforms => _platforms;

    private void OnValidate()
    {
        _neighborsFinder = GetComponent<PlatformNeighborsFinder>();
        if (_neighborsFinder == null)
        {
            Debug.LogWarning("PlatformNeighborsFinder doesn't set on PlatformMap");
            return;
        } 
        
        var firstPlatformInCurrentRow = GameObjectUtils.GetChildrenWithTag(gameObject, TagEnum.FirstPlatform)
            .GetComponent<Platform>();

        if (firstPlatformInCurrentRow == null)
        {
            Debug.LogError("There is no first platform in map");
            return;
        }

        _platforms = new List<List<Platform>>();
        while (firstPlatformInCurrentRow != null)
        {
           _platforms.Add(GetPlatformsInCurrentRow(firstPlatformInCurrentRow));
           firstPlatformInCurrentRow = firstPlatformInCurrentRow.Neighbors.Bottom;
        }

        _rowCount = _platforms.Count;
        _columnCount = _platforms[0].Count;
    }

    private List<Platform> GetPlatformsInCurrentRow(Platform firstPlatformInRow)
    {
        var row = new List<Platform>();
        var currentPlatform = firstPlatformInRow;
        while (currentPlatform != null)
        {
            _neighborsFinder.FindNeighbors(currentPlatform);
            row.Add(currentPlatform);
            currentPlatform = currentPlatform.Neighbors.Right;
        }

        return row;
    }
}
