using UnityEngine;

public class EnemyGenerator : Singleton<EnemyGenerator>
{

    public GameObject GenerateEnemyWithConfig(EnemyGenerationConfig generationConfig)
    {
        return GenerateRandomEnemyOnRandomPosition();
    }
    
    public GameObject GenerateRandomEnemyOnRandomPosition()
    {
        var freePlatform = RandomUtils.GetRandomObjectFromList(PlatformMap.Instance.FreePlatforms);
        if (freePlatform == null)
        {
            Debug.LogWarning("There is no free platform");
            return null;
        }

        var enemy = PoolManager.Instance.EnemyPool.GetObject().GetComponent<PlatformObject>();
        enemy.GetComponent<Liveble>().InitHp();
        enemy.GetComponent<HpLampController>().InitLamps();
        enemy.gameObject.SetActive(true);
        enemy.SetPlace(freePlatform);
        freePlatform.SetCurrentObject(enemy);
        return enemy.gameObject;
    }
}
