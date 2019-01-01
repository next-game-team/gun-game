using UnityEngine;

[CreateAssetMenu(fileName = "BulletConfig", menuName = "Create Bullet config")]
public class BulletConfig : ScriptableObject
{
    public int DamageCount;
    public float Speed;
    public float Lifetime = 5;
}