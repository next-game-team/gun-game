using UnityEngine;

public class PlayerWithTimeCollectableController : PlayerCollectableController
{
    [SerializeField]
    private float _timeEnergyValue;
    
    private PlayerAttackWithTimeManager _attackWithTimeManager;

    private void Awake()
    {
        _attackWithTimeManager = GetComponent<PlayerAttackWithTimeManager>();
    }

    public override void Collect(CollectableObject collectableObject)
    {
        switch (collectableObject.Type)
        {
            case CollectableType.TimeEnergy:
                CollectTimeEnergy();
                break;
        }
    }

    private void CollectTimeEnergy()
    {
        _attackWithTimeManager.IncreaseTimeEnergy(_timeEnergyValue);
    }
}