using UnityEngine;
using UnityEngine.Events;

public class DieEvent : UnityEvent<Dieble>
{
    
}

public abstract class Dieble : MonoBehaviour
{
    public DieEvent OnDieEvent { get; } = new DieEvent();

    public virtual void Die()
    {
        OnDieEvent.Invoke(this);
    }
}