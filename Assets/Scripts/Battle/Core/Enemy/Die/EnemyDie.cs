using UnityEngine;

public class EnemyDie : CommonDieInPool
{
    private Animator _animator;
    private Liveble _liveble;

    private void Start()
    {
        Pool = PoolManager.Instance.EnemyPool;
        _animator = GetComponent<Animator>();
    }

    protected override void Die(Liveble liveble)
    {
        _liveble = liveble;
        _animator.SetTrigger(AnimationConsts.DieTrigger);
    }

    // Called from AnimationController when die animation is dead
    public void OnDieEnd()
    {
        // Empty platform
        var platformObject = GetComponent<PlatformObject>();
        if (platformObject != null)
        {
            platformObject.CurrentPlace.Empty();
        }
        
        base.Die(_liveble);
    } 
}