using UnityEngine;

public class CommonDieInPool : Dieble
{
    protected Pool Pool { get; set; }
    
    protected override void Die(Liveble liveble)
    {
        if (Pool == null)
        {
            Debug.LogError("Pool is not set for Dieble: " + this);
            return;
        }
        
        Pool.ReturnObject(gameObject);
    }
}