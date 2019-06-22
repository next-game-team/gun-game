using UnityEngine;

public class PlayerWithEnergyCollectableController : PlayerCollectableController
{
    
    private PlayerAttackWithEnergyManager _playerAttackManager;

    private void Awake()
    {
        _playerAttackManager = GetComponent<PlayerAttackWithEnergyManager>();
    }

    public override void Collect(CollectableObject collectableObject)
    {
        base.Collect(collectableObject);
        switch (collectableObject.Type)
        {
            case CollectableType.TimeEnergy:
                CollectTimeEnergy();
                break;
        }
    }

    private void CollectTimeEnergy()
    {
        _playerAttackManager.AddEnergy(1);
    }
}