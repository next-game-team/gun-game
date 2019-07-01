using UnityEngine;

public class PlayerAttackController : AttackController
{
    public delegate bool AttackStartEvent();
    public event AttackStartEvent OnAttackStartEvent;

    private bool _isInAttack;

    protected override void CheckInput()
    {
        if (!_isInAttack && 
            (Input.GetKeyDown(KeyCode.Space) 
             || TouchManager.Instance.AttackTouchState == TouchManager.TouchState.Touch))
        {
            _isInAttack = true;
            OnAttackStartEvent?.Invoke();
        }
        else if (_isInAttack && (Input.GetKeyUp(KeyCode.Space) 
                                 || TouchManager.Instance.AttackTouchState == TouchManager.TouchState.TouchEnd))
        {
            _isInAttack = false;
            if (TouchManager.Instance.AttackTouchState == TouchManager.TouchState.TouchEnd)
            {
                TouchManager.Instance.AttackTouchState = TouchManager.TouchState.Idle;
            }
            AttackEvent?.Invoke();
        }
    }
}