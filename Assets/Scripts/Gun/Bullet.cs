using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public BulletConfig BulletConfig { get; private set; }

    private bool _isAlive;
    private float _currentLifeTime;
    private Rigidbody2D _rb;
    private Vector2 _bulletVelocity;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Init(BulletConfig bulletConfig, Vector2 velocity, Quaternion rotation)
    {
        gameObject.SetActive(true);
        BulletConfig = bulletConfig;
        transform.rotation = rotation;
        _isAlive = true;
        _currentLifeTime = bulletConfig.Lifetime;
        _bulletVelocity = velocity * bulletConfig.Speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isAlive) return;

        if (_currentLifeTime > 0)
        {
            _currentLifeTime -= Time.deltaTime;
            _rb.velocity = _bulletVelocity;
        }
        else
        {
            DestroyBullet();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameObjectUtils.CompareLayerWithMask(other.gameObject, BulletConfig.WhatIsTarget))
        {
            Damageble damageble = other.gameObject.GetComponent<Damageble>();
            if(damageble != null)
            {
                damageble.ReceiveDamage(new DamageInfo(BulletConfig.DamageCount, transform.position));
            }
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        _rb.velocity = Vector2.zero;
        _isAlive = false;
        PoolManager.Instance.BulletPool.ReturnObject(gameObject);
    }
}
