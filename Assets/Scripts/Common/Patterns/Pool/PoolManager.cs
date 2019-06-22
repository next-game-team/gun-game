using UnityEngine;

public class PoolManager : TagPoolManager<PoolManager, TagEnum> {
    
    public Pool BulletPool { get; private set; }
    public Pool EnemyPool { get; private set; }
    public Pool CollectablePool { get; private set; }

    private void Awake()
    {
        BulletPool = InitPool(TagEnum.BulletPool);
        EnemyPool = InitPool(TagEnum.EnemyPool);
        CollectablePool = InitPool(TagEnum.CollectablePool);
    }
}
