public class EnemyDie : CommonDieInPool
{
    private void Awake()
    {
        Pool = PoolManager.Instance.EnemyPool;
    }
}