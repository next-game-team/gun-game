using UnityEngine;

public class PlayerAttackController : AttackController
{
    public delegate void AttackStartEvent();
    public event AttackStartEvent OnAttackStartEvent;

    protected override void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnAttackStartEvent?.Invoke();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            AttackEvent?.Invoke();
        }
    }
}