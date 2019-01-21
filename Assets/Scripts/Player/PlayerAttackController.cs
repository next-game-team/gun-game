using UnityEngine;

public class PlayerAttackController : AttackController
{
    public delegate void AttackStartEvent();
    public event AttackStartEvent OnAttackStartEvent;
    
    private void Update()
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