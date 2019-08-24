using UnityEngine;

[RequireComponent(typeof(PlatformMap))]
public class PlatformMapGenerator : AbstractMapGenerator<Platform, PlatformType>
{
    [SerializeField] private int _rowCount;
    [SerializeField] private int _columnCount;
    [SerializeField] private GameObject _mapContainer;
    [SerializeField] private bool _enableOnRowCreated;

    public int RowCount => _rowCount;
    public int ColumnCount => _columnCount;
    
    private PlatformMap _platformMap;

    private void Awake()
    {
        Init();
    }

    private void OnValidate()
    {
        Init();
    }

    private void Init()
    {
        _platformMap = GetComponent<PlatformMap>();
        InitConsts();
    }

    public void GenerateMap()
    {
        _platformMap.CleanChildren();
        var currentPosition = new Vector2(_mapContainer.transform.position.x, _mapContainer.transform.position.y);
        for (var rowInd = 0; rowInd < RowCount; rowInd++)
        {
            GenerateRow(rowInd, currentPosition);
            currentPosition += Vector2.down * DistanceBetweenRows;
        }
    }

    private void GenerateRow(int rowInd, Vector2 currentPosition)
    {
        for (var columnInd = 0; columnInd < _columnCount; columnInd++)
        {
            var platform = Instantiate(PlacePrefab,
                currentPosition + Vector2.right * DistanceBetweenColumns * columnInd,
                Quaternion.identity,
                _mapContainer.transform);
            platform.SidePoints.Init();
            platform.gameObject.name = "Platform-" + (rowInd + 1) + "-" + (columnInd + 1);
            OnRowCreated(rowInd, columnInd, platform);
            
            // Set FirstPlatform tag to first platform
            if (rowInd == 0 && columnInd == 0)
            {
                platform.tag = TagUtils.GetTagNameByEnum(TagEnum.FirstPlatform);
            }
        }
    }

    protected void OnRowCreated(int rowInd, int columnInd, Platform platform)
    {
        if (!_enableOnRowCreated) return;
        
        // Create bottom line
        if (rowInd < RowCount - 1)
        {
            CreateLine(DirectionEnum.DOWN, platform);
        }
        
        // Create right line
        if (columnInd < ColumnCount - 1)
        {
            CreateLine(DirectionEnum.RIGHT, platform);
        }
    }
}
