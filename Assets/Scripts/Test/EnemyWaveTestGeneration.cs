using UnityEngine;

public class EnemyWaveTestGeneration : MonoBehaviour
{
    [SerializeField] 
    private EnemyWaveConfig _enemyWaveConfig;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            EnemyWaveGenerator.GenerateWave(_enemyWaveConfig);
        }
    }
}