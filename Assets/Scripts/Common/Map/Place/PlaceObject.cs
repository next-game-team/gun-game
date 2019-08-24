using DG.Tweening;
using UnityEngine;

public abstract class PlaceObject<T, TP> : MonoBehaviour, Moveble where T : AbstractPlace<T, TP>
{
    [SerializeField]
    private float _moveDuration = 0.5f;

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

    public bool IsInMove { get; private set; }

    public void SetPlace(T place)
    {
        CurrentPlace = place;
        transform.position = place.transform.position;
    }

    public bool MoveToDirection(DirectionEnum direction)
    {
        return BetweenPlaceMover<T, TP>.MoveTo(this, direction);
    }
    
    public void MoveTo(T place)
    {
        CurrentPlace = place;
        IsInMove = true;
        var tween = transform.DOMove(place.transform.position, 
            MoveDuration);
        tween.onComplete += OnMoveEnd;
    }

    public abstract void ResolveEntering();

    private void OnMoveEnd()
    {
        IsInMove = false;
    }

    protected virtual void Awake()
    {
        
    }
}
