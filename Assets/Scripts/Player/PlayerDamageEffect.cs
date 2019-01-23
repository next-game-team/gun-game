using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageEffect : CharacterDamageEffect
{
    private CameraShakeController _shakeController;

    protected override void Awake()
    {
        base.Awake();
        _shakeController = FindObjectOfType<CameraShakeController>();
    }

    public override void OnDamageReceived(Damageble damageble, DamageInfo damageInfo)
    {
        base.OnDamageReceived(damageble, damageInfo);
        _shakeController.ShakedCamera();
    }

}
