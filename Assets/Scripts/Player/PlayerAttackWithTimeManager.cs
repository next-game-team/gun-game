using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(PlayerAttackController))]
public class PlayerAttackWithTimeManager : AttackManager<PlayerAttackController>
{

   [SerializeField]
   private PlayerAttackAimConfig _aimConfig;
   
   [SerializeField]
   private float _timeEnergyCapacity = 3f;
   public float TimeEnergyCapacity => _timeEnergyCapacity; 

   public float CurrentTimeEnergy { get; private set; }
   
   private bool _isInAttack;
   
   protected override void Awake()
   {
      base.Awake();
      AttackController.OnAttackStartEvent += OnAttackStart;
      CurrentTimeEnergy = _timeEnergyCapacity;
   }

   private void Update()
   {
      if (_isInAttack)
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
   }

   protected override void OnAttackEvent()
   {
      // If attack was called before
      if (_isInAttack == false) return;
      
      base.OnAttackEvent();
      Time.timeScale = 1;
      _isInAttack = false;
   }

   private void OnAttackStart()
   {
      if (Gun.IsInCooldown) return;

      Time.timeScale = _aimConfig.AimTimeScale;
      _isInAttack = true;
      CurrentTimeEnergy = TimeEnergyCapacity;
   }
}