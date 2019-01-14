using System.Collections.Generic;
using UnityEngine;

public static class LevelGenerator
{
    public static void GenerateWithConfig(LevelConfig levelConfig, Level level)
    {
        level.EnemyWaves = GenerateEnemyWavesList(levelConfig);
    }

    private static List<EnemyWaveConfig> GenerateEnemyWavesList(LevelConfig levelConfig)
    {
        var waves = new List<EnemyWaveConfig>();
        for (var waveInd = 0; waveInd < levelConfig.WavesCount; waveInd++)
        {
            waves.Add(GenerateEnemyWave(levelConfig));
        }

        return waves;
    }

    private static EnemyWaveConfig GenerateEnemyWave(LevelConfig levelConfig)
    {
        var enemies = new List<EnemyGenerationConfig>();
        for (var enemyInd = 0; enemyInd < levelConfig.EnemiesOnWaveCount; enemyInd++)
        {
            // Create EnemyGenerationConfig and fill it with special data
            var enemyConfig = ScriptableObject.CreateInstance<EnemyGenerationConfig>();
            // TODO : change choosing enemy config
            enemyConfig.EnemyType = EnemyType.Common;
            enemyConfig.GenerationPosition = EnemyGenerationPositionEnum.Any;
            enemies.Add(enemyConfig);
        }

        var waveConfig = ScriptableObject.CreateInstance<EnemyWaveConfig>();
        waveConfig.EnemiesOnWave = enemies;
        return waveConfig;
    }
}
