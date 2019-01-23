using UnityEngine;

[RequireComponent(typeof(PlayerAttackController))]
public class PlayerAttackManager : AttackManager<PlayerAttackController>
{

   [SerializeField]
   private PlayerAttackAimConfig _aimConfig;
   public PlayerAttackAimConfig AimConfig => _aimConfig;

   protected bool IsInAttack;
   
   protected override void Awake()
   {
      base.Awake();
      AttackController.OnAttackStartEvent += OnAttackStart;
   }

   protected override void OnAttackEvent()
   {
      // If attack was called before
      if (IsInAttack == false) return;
      
      base.OnAttackEvent();
      Time.timeScale = 1;
      IsInAttack = false;
   }

   protected virtual void OnAttackStart()
   {
      if (Gun.IsInCooldown) return;

      Time.timeScale = _aimConfig.AimTimeScale;
      IsInAttack = true;
   }
}