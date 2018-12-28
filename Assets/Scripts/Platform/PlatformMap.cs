using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformMap : MonoBehaviour
{

    [SerializeField] 
    private List<List<Platform>> _platforms;

    [SerializeField, ReadOnly] 
    private readonly int _rowCount;
    [SerializeField, ReadOnly] 
    private readonly int _columnCount;

    public List<List<Platform>> Platforms => _platforms;

    private void OnValidate()
    {
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
    }

    private static List<Platform> GetPlatformsInCurrentRow(Platform firstPlatformInRow)
    {
        var row = new List<Platform>();
        var currentPlatform = firstPlatformInRow;
        while (currentPlatform != null)
        {
            currentPlatform.GetComponent<PlatformNeighborsFinder>().FindNeighbors();
            row.Add(currentPlatform);
            currentPlatform = currentPlatform.Neighbors.Right;
        }

        return row;
    }
}
