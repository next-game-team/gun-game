using UnityEngine;

[RequireComponent(typeof(PlayerAttackController))]
public class PlayerAttackWithTimeManager : PlayerAttackManager
{
   
   [SerializeField]
   private PlayerTimeEnergyConfig _attackWithTimeConfig;
   public PlayerTimeEnergyConfig AttackWithTimeConfig => _attackWithTimeConfig;
   
   public float CurrentTimeEnergy { get; private set; }

   protected override void Awake()
   {
      base.Awake();
      CurrentTimeEnergy = AttackWithTimeConfig.TimeEnergyCapacity;
   }

   private void Update()
   {
      if (IsInAttack)
      {
         if (CurrentTimeEnergy <= 0)
         {
            OnAttackEvent();
         }
         else
         {
            CurrentTimeEnergy -= Time.unscaledDeltaTime;
         }
      }
      else
      {
         // Check if already fill capacity
         if (CurrentTimeEnergy >= AttackWithTimeConfig.TimeEnergyCapacity) return;
         
         CurrentTimeEnergy += AttackWithTimeConfig.TimeEnergyIncreaseValue * Time.deltaTime;
      }
   }
}