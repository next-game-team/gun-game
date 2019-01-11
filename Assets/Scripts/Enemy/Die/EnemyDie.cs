public class EnemyDie : CommonDieInPool
{
    private void Start()
    {
        Pool = PoolManager.Instance.EnemyPool;
    }

    protected override void Die(Liveble liveble)
    {
        var platformObject = GetComponent<PlatformObject>();
        if (platformObject != null)
        {
            platformObject.CurrentPlatform.EmptyPlatform();
        }
        base.Die(liveble);
    }
}