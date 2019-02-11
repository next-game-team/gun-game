using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWaveConfig", menuName = "Create Config/EnemyWave config")]
public class EnemyWaveConfig : ScriptableObject
{
    public List<EnemyGenerationConfig> EnemiesOnWave;
}