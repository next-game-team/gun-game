using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttackAimConfig", menuName = "Create Config/PlayerAttackAim config")]
public class PlayerAttackAimConfig : ScriptableObject
{
    public float AimTimeScale = 0.2f;
    public float TimeScaleDecreaseDuration = 0.5f;
    public float TimeScaleIncreaseDuration = 0.3f;
}