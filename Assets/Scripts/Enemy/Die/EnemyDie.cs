public class EnemyDie : CommonDieInPool
{
    private void Start()
    {
        Pool = PoolManager.Instance.EnemyPool;
    }
}