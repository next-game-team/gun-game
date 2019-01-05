using UnityEngine;

public class PlatformMapGenerator : MonoBehaviour
{
    [SerializeField] private int _rowCount;
    [SerializeField] private int _columnCount;
    [SerializeField] private float _distanceBetweenRows;
    [SerializeField] private float _distanceBetweenColumns;
    [SerializeField] private GameObject _mapContainer;
    [SerializeField] private Platform _platformPrefab;
    
    public void GenerateMap()
    {
        var currentPosition = new Vector2(_mapContainer.transform.position.x, _mapContainer.transform.position.y);
        for (var rowInd = 0; rowInd < _rowCount; rowInd++)
        {
            GenerateRow(rowInd, currentPosition);
            currentPosition += Vector2.down * _distanceBetweenRows;
        }
    }

    private void GenerateRow(int rowInd, Vector2 currentPosition)
    {
        for (var columnInd = 0; columnInd < _columnCount; columnInd++)
        {
            var platform = Instantiate(_platformPrefab,
                currentPosition + Vector2.right * _distanceBetweenColumns * columnInd,
                Quaternion.identity,
                _mapContainer.transform);
            platform.gameObject.name = "Platform-" + (rowInd + 1) + "-" + (columnInd + 1);

            // Set FirstPlatform tag to first platform
            if (rowInd == 0 && columnInd == 0)
            {
                platform.tag = TagUtils.GetTagNameByEnum(TagEnum.FirstPlatform);
            }
        }
    }
}
