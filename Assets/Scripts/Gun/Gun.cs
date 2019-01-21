using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GunConfig _gunConfig;

    [SerializeField] private Transform _shootPoint;

    public bool IsInCooldown { get; private set; }
    private float _currentCooldownTime;

    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!IsInCooldown) return;

        if (IsInCooldown && _currentCooldownTime > 0)
        {
            _currentCooldownTime -= Time.deltaTime;
        }
        else
        {
            IsInCooldown = false;
        }
    }

    public void Shoot()
    {
        if (IsInCooldown) return;

        IsInCooldown = true;
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
