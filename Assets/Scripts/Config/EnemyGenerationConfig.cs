using UnityEngine;

[CreateAssetMenu(fileName = "EnemyGenerationConfig", menuName = "Create Config/Enemy Generation config")]
public class EnemyGenerationConfig : ScriptableObject
{
    public EnemyType EnemyType;
    public EnemyGenerationPositionEnum GenerationPosition;
}