using UnityEngine;

[RequireComponent(typeof(PlayerAttackController))]
public class PlayerAttackManager : AttackManager<PlayerAttackController>
{  
   protected override void Awake()
   {
      base.Awake();
      AttackController.OnAttackStartEvent += OnAttackStart;
   }

   protected override void OnAttackEvent()
   {
      base.OnAttackEvent();
   }

   private void OnAttackStart()
   {
      
   }
}