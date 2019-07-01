using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerAttackController))]
public class PlayerAttackWithEnergyManager : PlayerAttackManager
{
   [SerializeField] private int _maxEnergyCount;
   public int MaxEnergyCount => _maxEnergyCount;
   
   public float CurrentEnergyCount { get; private set; }

   [NonSerialized] public OnEnergyChangeEvent OnEnergyIncrease;
   [NonSerialized] public OnEnergyChangeEvent OnEnergyDecrease;

   protected override void Awake()
   {
      base.Awake();
      CurrentEnergyCount = MaxEnergyCount;
      OnEnergyIncrease = new OnEnergyChangeEvent();
      OnEnergyDecrease = new OnEnergyChangeEvent();
   }

   protected override bool OnAttackStart()
   {
      if (CurrentEnergyCount <= 0) return false;
      
      if (!base.OnAttackStart()) return false;

      CurrentEnergyCount--;
      OnEnergyDecrease?.Invoke(1);
      return true;
   }

   public void AddEnergy(int energyCount)
   {
      CurrentEnergyCount += energyCount;
      OnEnergyIncrease?.Invoke(energyCount);
   }
}

public class OnEnergyChangeEvent : UnityEvent<int>
{
}