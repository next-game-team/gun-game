using UnityEngine;

public class EnemyGenerator : Singleton<EnemyGenerator>
{
    public void GenerateRandomEnemyOnRandomPosition()
    {
        var freePlatform = RandomUtils.GetRandomObjectFromList(PlatformMap.Instance.FreePlatforms);
        if (freePlatform == null)
        {
            Debug.LogWarning("There is no free platform");
        } 
        
        freePlatform.SetPlatformObject(PoolManager.Instance.EnemyPool.GetObject().GetComponent<PlatformObject>());
    }
}
