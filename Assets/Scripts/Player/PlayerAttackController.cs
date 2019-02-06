using UnityEngine;

public class PlayerAttackController : AttackController
{
    public delegate void AttackStartEvent();
    public event AttackStartEvent OnAttackStartEvent;

    protected override void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) ||
            // Check if user tap on screen (1 touch) or tap while swiping (2 touches) 
            Input.touchCount == (TouchManager.Instance.IsInDrag ? 2 : 1))
        {
            OnAttackStartEvent?.Invoke();
        }
        else if (Input.GetKeyUp(KeyCode.Space) ||
                 Input.touchCount == (TouchManager.Instance.IsInDrag ? 1 : 0))
        {
            AttackEvent?.Invoke();
        }
    }
}