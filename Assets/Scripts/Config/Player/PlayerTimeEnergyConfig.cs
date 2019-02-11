using UnityEngine;

[CreateAssetMenu(fileName = "PlayerTimeEnergyConfig", menuName = "Create Config/PlayerTimeEnergy config")]
public class PlayerTimeEnergyConfig : ScriptableObject
{
    public float TimeEnergyCapacity = 3f;
    public float TimeEnergyIncreaseValue = 0.5f;
}