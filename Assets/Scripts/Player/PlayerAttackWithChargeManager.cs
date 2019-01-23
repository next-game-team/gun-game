using UnityEngine;

[RequireComponent(typeof(PlayerAttackController))]
public class PlayerAttackWithChargeManager : PlayerAttackManager
{  
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

   protected override void OnAttackStart()
   {
      base.OnAttackStart();
      
      _currentAimTime = AimConfig.AimTime;
   }
}