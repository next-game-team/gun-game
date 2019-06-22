using UnityEngine;

public class TimeEnergyManager : MonoBehaviour
{
    [SerializeField] private float _spawnTime = 2f;

    private float _currentSpawnTime;

    private void Update()
    {
        if (!LevelManager.Instance.CurrentLevel.IsPlayed) return;   
        
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
        var platformToGenerate = PlatformUtils.GetRandomPlatformForCollectable();
        if (platformToGenerate == null) return;
        
        // Generate time energy collectable
        var collectable = PoolManager.Instance.CollectablePool.GetObject().GetComponent<CollectableObject>();
        collectable.Type = CollectableType.TimeEnergy;
        platformToGenerate.SetCollectableObject(collectable);
        collectable.gameObject.SetActive(true);
    }
}