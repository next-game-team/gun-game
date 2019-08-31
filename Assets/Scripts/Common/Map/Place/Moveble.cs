using UnityEngine.Events;

public interface Moveble
{
    bool IsInMove { get; }
    
    UnityEvent OnMoveEndEvent { get; }
    
    bool MoveToDirection(DirectionEnum direction);
}