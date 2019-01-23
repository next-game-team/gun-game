using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttackAimConfig", menuName = "Create PlayerAttackAim config")]
public class PlayerAttackAimConfig : ScriptableObject
{
    public float AimTime = 0.4f;
    public float AimTimeScale = 0.2f;
    public float TimeScaleDecreaseDuration = 0.5f;
    public float TimeScaleIncreaseDuration = 0.3f;
}