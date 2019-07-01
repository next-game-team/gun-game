using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Damageble))]
public class CharacterCollisionHandler : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsBullet;

    private Damageble _damageble;

    private void Awake()
    {
        _damageble = GetComponent<Damageble>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameObjectUtils.CompareLayerWithMask(other.gameObject, _whatIsBullet))
        {
            var bullet = other.GetComponent<Bullet>();
            _damageble.ReceiveDamage(new DamageInfo(bullet.BulletConfig.DamageCount, bullet.transform.position));
        }
    }
}
