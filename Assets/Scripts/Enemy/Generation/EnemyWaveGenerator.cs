using System.Collections.Generic;
using UnityEngine;

public static class EnemyWaveGenerator
{
    public static List<GameObject> GenerateWaveEnemies(EnemyWaveConfig enemyWaveConfig)
    {
        var enemies = new List<GameObject>();
        // Generate each enemy with config
        foreach (var enemyGenerationConfig in enemyWaveConfig.EnemiesOnWave)
        {
            enemies.Add(EnemyGenerator.Instance.GenerateEnemyWithConfig(enemyGenerationConfig));
        }

        return enemies;
    }
}
