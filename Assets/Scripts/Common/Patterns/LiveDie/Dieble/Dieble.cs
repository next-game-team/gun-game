using UnityEngine;

public abstract class Dieble : MonoBehaviour
{
    protected abstract void Die(Liveble liveble);

    private void Awake()
    {
        GetComponent<Liveble>().OnDieEvent += Die;
    }
}