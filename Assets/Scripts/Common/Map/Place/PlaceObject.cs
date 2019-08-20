using DG.Tweening;
using UnityEngine;

public class PlaceObject<T> : MonoBehaviour, Moveble where T : AbstractPlace<T>
{
    [SerializeField] 
    private float _moveDuration = 0.5f;
    
    public ICollectableController CollectableController { get; private set; }

    public float MoveDuration
    {
        get { return _moveDuration; }
        set { _moveDuration = value; }
    }

    [SerializeField, ReadOnly]
    private T _currentPlace;

    public T CurrentPlace
    {
        get { return _currentPlace; }
        set { _currentPlace = value; }
    }

    private PlaceObjectPosition<T> _objectPosition;
    
    public bool IsInMove { get; private set; }

    public void SetPlace(T place)
    {
        CurrentPlace = place;
        transform.position = _objectPosition.GetPosition(place);
    }

    public bool MoveToDirection(DirectionEnum direction)
    {
        return BetweenPlaceMover<T>.MoveTo(this, direction);
    }
    
    public void MoveTo(T place)
    {
        CurrentPlace = place;
        IsInMove = true;
        var tween = transform.DOMove(_objectPosition.GetPosition(place), 
            MoveDuration);
        tween.onComplete += OnMoveEnd;
    }

    private void OnMoveEnd()
    {
        IsInMove = false;
    }

    protected virtual void Awake()
    {
        _objectPosition = GetComponent<PlaceObjectPosition<T>>();
        CollectableController = GetComponent<ICollectableController>();
    }
}
