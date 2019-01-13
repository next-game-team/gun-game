using UnityEngine;

[CreateAssetMenu(fileName = "EnemyGenerationConfig", menuName = "Create Enemy Generation config")]
public class EnemyGenerationConfig : ScriptableObject
{
    public EnemyType EnemyType;
    public EnemyGenerationPositionEnum GenerationPosition;
}