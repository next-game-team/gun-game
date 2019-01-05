using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Liveble))]
public class CharacterCollisionHandler : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsBullet;

    private Liveble _liveble;

    private void Awake()
    {
        _liveble = GetComponent<Liveble>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameObjectUtils.CompareLayerWithMask(other.gameObject, _whatIsBullet))
        {
            var bullet = other.GetComponent<Bullet>();
            _liveble.DecreaseHp(bullet.BulletConfig.DamageCount);
        }
    }
}
