using UnityEngine;

public class PoolManager : Singleton<PoolManager> {
    
    public Pool BulletPool { get; private set; }
    public Pool EnemyPool { get; private set; }

    private void Awake()
    {
        BulletPool = InitPool(TagEnum.BulletPool);
        EnemyPool = InitPool(TagEnum.EnemyPool);
    }

    private static Pool InitPool(TagEnum tagEnum)
    {
        var pool = GameObject             
            .FindGameObjectWithTag(TagUtils.GetTagNameByEnum(tagEnum))
            .GetComponent<Pool>();
        pool.Init();
        return pool;
    }
}
