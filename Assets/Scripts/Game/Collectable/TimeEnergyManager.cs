using UnityEngine;

public class TimeEnergyManager : MonoBehaviour
{
    [SerializeField] private float _spawnTime = 2f;

    private float _currentSpawnTime;

    private void Update()
    {
        if (_currentSpawnTime <= 0)
        {
            Spawn();
            _currentSpawnTime = _spawnTime;
        }
        else
        {
            _currentSpawnTime -= Time.deltaTime;
        }
    }

    private void Spawn()
    {
        // Find platform to generate
        var freePlatformsWithoutCollectable = PlatformMap.Instance
            .FreePlatforms
            .FindAll(platform => platform.CollectableObject == null);
        var platformToGenerate = RandomUtils.GetRandomObjectFromList(freePlatformsWithoutCollectable);
        
        // Generate time energy collectable
        var collectable = PoolManager.Instance.CollectablePool.GetObject().GetComponent<CollectableObject>();
        collectable.Type = CollectableType.TimeEnergy;
        platformToGenerate.SetCollectableObject(collectable);
        collectable.gameObject.SetActive(true);
    }
}