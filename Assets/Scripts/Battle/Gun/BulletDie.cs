public class BulletDie : CommonDieInPool
{
    private void Awake()
    {
        Pool = PoolManager.Instance.BulletPool;
    }
}