using UnityEngine;

public class SimpleEnemyDie : CommonDieInPool
{

    private void Start()
    {
        Pool = PoolManager.Instance.EnemyPool;
    }

    protected override void Die(Liveble liveble)
    {
        OnDieEnd(liveble);
    }

    // Called from AnimationController when die animation is dead
    public void OnDieEnd(Liveble liveble)
    {
        // Empty platform
        var platformObject = GetComponent<PlatformObject>();
        if (platformObject != null)
        {
            platformObject.CurrentPlatform.EmptyPlatform();
        }
        
        base.Die(liveble);
    } 
}