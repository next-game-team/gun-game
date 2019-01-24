using UnityEngine;

[RequireComponent(typeof(PlayerAttackController))]
public class PlayerAttackManager : AttackManager<PlayerAttackController>
{

   [SerializeField]
   private PlayerAttackAimConfig _aimConfig;
   public PlayerAttackAimConfig AimConfig => _aimConfig;

   private GunRayController _gunRayController;

   protected bool IsInAttack;
   
   protected override void Awake()
   {
      base.Awake();
      _gunRayController = Gun.GetComponent<GunRayController>();
      AttackController.OnAttackStartEvent += OnAttackStart;
   }

   protected override void OnAttackEvent()
   {
      // If attack was called before
      if (IsInAttack == false) return;
      
      base.OnAttackEvent();
      GameManager.Instance.SetTimeScale(1);
      IsInAttack = false;
      _gunRayController.TurnOff();
   }

   protected virtual void OnAttackStart()
   {
      if (Gun.IsInCooldown) return;

      GameManager.Instance.SetTimeScale(_aimConfig.AimTimeScale);
      IsInAttack = true;
      _gunRayController.TurnOn();
   }
}