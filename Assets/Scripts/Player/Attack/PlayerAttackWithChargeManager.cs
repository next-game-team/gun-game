using UnityEngine;

[RequireComponent(typeof(PlayerAttackController))]
public class PlayerAttackWithChargeManager : PlayerAttackManager
{
   [SerializeField] private PlayerAttackChargeConfig _attackChargeConfig;
   
   private float _currentAimTime;

   private void Update()
   {
      if (IsInAttack)
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

   protected override bool OnAttackStart()
   {
      if (!base.OnAttackStart()) return false;
      
      _currentAimTime = _attackChargeConfig.ChargeTime;
      return true;
   }
}