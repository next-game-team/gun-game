using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(PlayerAttackController))]
public class PlayerAttackManager : AttackManager<PlayerAttackController>
{

   [SerializeField]
   private PlayerAttackAimConfig _aimConfig;
   
   private float _currentAimTime;
   private bool _isInAttack;
   
   protected override void Awake()
   {
      base.Awake();
      AttackController.OnAttackStartEvent += OnAttackStart;
   }

   private void Update()
   {
      if (_isInAttack)
      {
         if (_currentAimTime <= 0)
         {
            OnAttackEvent();
         }
         else
         {
            _currentAimTime -= Time.deltaTime;
         }
      }
   }

   protected override void OnAttackEvent()
   {
      // If attack was called before
      if (_isInAttack == false) return;
      
      base.OnAttackEvent();
      _isInAttack = false;
      Time.timeScale = 1;
   }

   private void OnAttackStart()
   {
      if (Gun.IsInCooldown) return;

      _isInAttack = true;
      _currentAimTime = _aimConfig.AimTime;

      Time.timeScale = _aimConfig.AimTimeScale;
   }
}