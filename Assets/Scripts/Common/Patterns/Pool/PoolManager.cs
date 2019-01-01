using UnityEngine;

public class PoolManager : Singleton<PoolManager> {
    
    public Pool BulletPool { get; private set; }

    private void Awake()
    {
        BulletPool = InitPool(TagEnum.BulletPool);
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
