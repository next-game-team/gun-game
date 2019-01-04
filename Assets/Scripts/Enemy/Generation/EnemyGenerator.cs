using UnityEngine;

public class EnemyGenerator : Singleton<EnemyGenerator>
{
    public void GenerateRandomEnemyOnRandomPosition()
    {
        var freePlatform = RandomUtils.GetRandomObjectFromList(PlatformMap.Instance.FreePlatforms);
        if (freePlatform == null)
        {
            Debug.LogWarning("There is no free platform");
            return;
        }

        var enemy = PoolManager.Instance.EnemyPool.GetObject().GetComponent<PlatformObject>();
        enemy.gameObject.SetActive(true);
        freePlatform.SetPlatformObject(enemy);
    }
}
