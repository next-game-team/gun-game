using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Create Level config")]
public class LevelConfig : ScriptableObject
{
    public int WavesCount;
    public int EnemiesOnWaveCount;
}