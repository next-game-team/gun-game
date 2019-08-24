using UnityEngine;

public class AbstractMapGenerator<T, TP> : MonoBehaviour where T : AbstractPlace<T, TP>
{
    [SerializeField] private float _distanceBetweenRows;
    [SerializeField] private float _distanceBetweenColumns;
    [SerializeField] private T _placePrefab;
    [SerializeField] private GameObject _linePrefab;

    public float DistanceBetweenRows => _distanceBetweenRows;
    public float DistanceBetweenColumns => _distanceBetweenColumns;
    public T PlacePrefab => _placePrefab;

    public GameObject LinePrefab => _linePrefab;
    

    [SerializeField, ReadOnly]
    private float _placePrefabSize;
    [SerializeField, ReadOnly]
    private float _linePrefabSize;

    private float lineSizeVertical;
    private float lineSizeHorizontal;
    private float linePositionDeltaVertical;
    private float linePositionDeltaHorizontal;

    protected void InitConsts()
    {
        _placePrefabSize = PlacePrefab.GetComponent<SpriteRenderer>().size.y;

        if (LinePrefab != null)
        {
            _linePrefabSize = LinePrefab.GetComponent<SpriteRenderer>().size.y;   
        }

        linePositionDeltaVertical = DistanceBetweenRows / 2;
        linePositionDeltaHorizontal = DistanceBetweenColumns / 2;

        lineSizeVertical = DistanceBetweenRows - _placePrefabSize;
        lineSizeHorizontal = DistanceBetweenColumns - _placePrefabSize;
    }

    protected GameObject CreateLine(DirectionEnum direction, T place)
    {
        var isVertical = DirectionUtils.IsVerticalDirection(direction);
        Vector3 linePositionDelta = DirectionUtils.vectorDirectionDictionary[direction]
                                * (isVertical ? linePositionDeltaVertical : linePositionDeltaHorizontal);
        var line = Instantiate(LinePrefab,
            place.transform.position + linePositionDelta,
            Quaternion.identity, place.transform);

        if (!isVertical)
        {
            line.transform.Rotate(0, 0, 90);
        }

        var lineSize = isVertical ? lineSizeVertical : lineSizeHorizontal;

        line.GetComponent<SpriteRenderer>().size += Vector2.up * (lineSize - _linePrefabSize);
        return line;
    }
}