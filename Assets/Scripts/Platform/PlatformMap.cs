using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlatformNeighborsFinder))]
[RequireComponent(typeof(PlatformMapGenerator))]
public class PlatformMap : Singleton<PlatformMap>
{

    [SerializeField] 
    private List<List<Platform>> _platforms;

    [SerializeField, ReadOnly] 
    private List<Platform> _freePlatforms;

    [SerializeField, ReadOnly] 
    private int _rowCount;
    [SerializeField, ReadOnly] 
    private int _columnCount;

    private PlatformNeighborsFinder _neighborsFinder;
    private PlatformMapGenerator _mapGenerator;
    
    public List<List<Platform>> Platforms => _platforms;
    public List<Platform> FreePlatforms => _freePlatforms;

    private void Awake()
    {
        FindMap();
        FindFreeNeighbors();
    }

    public List<Platform> FindFreeNeighbors()
    {
        _freePlatforms = new List<Platform>();

        foreach (var row in _platforms)
        {
            foreach (var platform in row)
            {
                if (platform.IsFree)
                {
                    _freePlatforms.Add(platform);
                }
            }
        }

        return _freePlatforms;
    }

    public void FindMap()
    {
        // Get finder and check if exist
        _neighborsFinder = GetComponent<PlatformNeighborsFinder>();
        if (_neighborsFinder == null)
        {
            Debug.LogWarning("PlatformNeighborsFinder doesn't set on PlatformMap");
            return;
        }
        
        // Get PlatformMapGenerator and check if exist
        _mapGenerator = GetComponent<PlatformMapGenerator>();
        if (_mapGenerator == null)
        {
            Debug.LogWarning("PlatformMapGenerator doesn't set on PlatformMap");
            return;
        }

        // Find First Platform and Check if exist
        var gameObjectWithTag = GameObjectUtils.GetChildrenWithTag(gameObject, TagEnum.FirstPlatform);
        if (gameObjectWithTag == null)
        {
            Debug.LogWarning("There is no first platform in map");
            return;
        }
        
        // Get Map
        var firstPlatformInCurrentRow = gameObjectWithTag.GetComponent<Platform>();
        _platforms = new List<List<Platform>>();
        while (firstPlatformInCurrentRow != null)
        {
            if (_platforms.Count > _mapGenerator.RowCount)
            {
                throw new UnityException("Rows more than in generator. Something when wrong..."
                                         + firstPlatformInCurrentRow.gameObject.name);
            }
           _platforms.Add(GetPlatformsInCurrentRow(firstPlatformInCurrentRow));
           firstPlatformInCurrentRow = firstPlatformInCurrentRow.Neighbors.Bottom;
        }

        // Save info about map size
        _rowCount = _platforms.Count;
        _columnCount = _platforms[0].Count;
    }

    private List<Platform> GetPlatformsInCurrentRow(Platform firstPlatformInRow)
    {
        var row = new List<Platform>();
        var currentPlatform = firstPlatformInRow;
        while (currentPlatform != null)
        {
            if (row.Count > _mapGenerator.RowCount)
            {
                throw new UnityException("Columns more than in generator. Something when wrong... " 
                                         + currentPlatform.gameObject.name);
            }
            
            _neighborsFinder.FindNeighbors(currentPlatform);
            row.Add(currentPlatform);
            currentPlatform = currentPlatform.Neighbors.Right;
        }

        return row;
    }

    public void CleanChildren()
    {
        var children = new List<GameObject>();
        foreach (Transform child in transform) children.Add(child.gameObject);
        children.ForEach(DestroyImmediate);
    }
}
