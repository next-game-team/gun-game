using UnityEngine;

[CreateAssetMenu(fileName = "BulletConfig", menuName = "Create Config/Bullet config")]
public class BulletConfig : ScriptableObject
{
    public LayerMask WhatIsTarget;
    public int DamageCount;
    public float Speed;
    public float Lifetime = 5;
}