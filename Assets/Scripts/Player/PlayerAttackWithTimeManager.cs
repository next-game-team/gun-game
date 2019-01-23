using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(PlayerAttackController))]
public class PlayerAttackWithTimeManager : AttackManager<PlayerAttackController>
{

   [SerializeField]
   private PlayerAttackAimConfig _aimConfig;

   [SerializeField] private float _timeEnergyCapacity = 1f;
   public float TimeEnergyCapacity => _timeEnergyCapacity;

   public float CurrentTimeEnergy { get; private set; }
   
   private bool _isInAttack;
   
   protected override void Awake()
   {
      base.Awake();
      AttackController.OnAttackStartEvent += OnAttackStart;
   }

   private void Update()
   {
      
   }

   protected override void OnAttackEvent()
   {
      // If attack was called before
      if (_isInAttack == false) return;
      
      base.OnAttackEvent();
      Time.timeScale = 1;
   }

   private void OnAttackStart()
   {
      if (Gun.IsInCooldown) return;

      Time.timeScale = _aimConfig.AimTimeScale;
   }
}