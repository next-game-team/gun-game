using UnityEngine;

public class PlayerPlatformEnterResolver : PlatformEnterResolver
{
    
    [SerializeField]
    private int _energyValue = 1;
    
    [SerializeField]
    private PlayerAttackWithEnergyManager _attackManager;

    public override void Resolve(Platform place)
    {
        switch (place.Type)
        {
            case PlatformType.Start:
                LevelManager.Instance.GenerateNextLevel();
                LevelManager.Instance.CurrentLevel.StartLevel();
                _attackManager.FullFillEnergy();
                break;
            case PlatformType.Energy:
                CollectEnergy();
                break;
        }
        place.SetType(PlatformType.Empty);
    }
    
    private void CollectEnergy()
    {
        _attackManager.AddEnergy(_energyValue);
    }
}