using UnityEngine;
using UnityEngine.Events;

public abstract class Dieble : MonoBehaviour
{
    public delegate void DieEvent(Dieble dieble);
    public event DieEvent OnDieEvent;

    public virtual void Die()
    {
        OnDieEvent?.Invoke(this);
    }
}