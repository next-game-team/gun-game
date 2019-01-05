public class EnemyDie : CommonDieInPool
{
    private void Start()
    {
        Pool = PoolManager.Instance.EnemyPool;
    }

    public override void Die()
    {
        var platformObject = GetComponent<PlatformObject>();
        if (platformObject != null)
        {
            platformObject.CurrentPlatform.EmptyPlatform();
        }
        base.Die();
    }
}