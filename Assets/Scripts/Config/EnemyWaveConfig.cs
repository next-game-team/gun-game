using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWaveConfig", menuName = "Create EnemyWave config")]
public class EnemyWaveConfig : ScriptableObject
{
    public List<EnemyGenerationConfig> EnemiesOnWave;
}