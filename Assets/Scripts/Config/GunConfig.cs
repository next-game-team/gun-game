using UnityEngine;

[CreateAssetMenu(fileName = "GunConfig", menuName = "Create Config/Gun config")]
public class GunConfig : ScriptableObject
{
    public float RotationSpeed;
    public float CooldownTime;
    public BulletConfig BulletConfig;
}