using UnityEngine;

public class PoolManager : Singleton<PoolManager> {
    
    private void Awake()
    {
        // Initialize all your pools
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
