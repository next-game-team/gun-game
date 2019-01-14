﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GunConfig _gunConfig;

    [SerializeField] private Transform _shootPoint;

    private bool _isInCooldown;
    private float _currentCooldownTime;

    private Animator _anim;


    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }


    private void Update()
    {
        if (!_isInCooldown) return;

        if (_isInCooldown && _currentCooldownTime > 0)
        {
            _currentCooldownTime -= Time.deltaTime;
        }
        else
        {
            _isInCooldown = false;
        }
    }

    public void Shoot()
    {
        if (_isInCooldown) return;

        _isInCooldown = true;
        _currentCooldownTime = _gunConfig.CooldownTime;
        
        var bullet = PoolManager.Instance.BulletPool.GetObject(_shootPoint.position).GetComponent<Bullet>();
        bullet.Init(_gunConfig.BulletConfig, GetCurrentVelocityVector(), transform.rotation);
        
        _anim.SetTrigger(AnimationConsts.GunShoot);
    }

    private Vector2 GetCurrentVelocityVector()
    {
        return _shootPoint.position - transform.position;
    }
}
