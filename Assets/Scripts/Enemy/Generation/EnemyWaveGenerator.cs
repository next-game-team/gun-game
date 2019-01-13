public class EnemyWaveGenerator
{
    public static void GenerateWave(EnemyWaveConfig enemyWaveConfig)
    {
        foreach (var enemyGenerationConfig in enemyWaveConfig.EnemiesOnWave)
        {
            EnemyGenerator.Instance.GenerateEnemyWithConfig(enemyGenerationConfig);
        }
    }
}
