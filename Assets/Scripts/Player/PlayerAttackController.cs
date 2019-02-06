using UnityEngine;

public class PlayerAttackController : AttackController
{
    public delegate void AttackStartEvent();
    public event AttackStartEvent OnAttackStartEvent;

    private bool _attackByTouch = false;

    protected override void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) ||
            // Check if user tap on screen (1 touch) or tap while swiping (2 touches) 
            Input.touchCount == (TouchManager.Instance.IsInDrag ? 2 : 1))
        {
            OnAttackStartEvent?.Invoke();
            _attackByTouch = Input.touchCount == (TouchManager.Instance.IsInDrag ? 2 : 1);
        }
        else if (Input.GetKeyUp(KeyCode.Space) ||
                 (Input.touchCount == (TouchManager.Instance.IsInDrag ? 1 : 0) && _attackByTouch))
        {
            AttackEvent?.Invoke();
            _attackByTouch = false;
        }
    }
}