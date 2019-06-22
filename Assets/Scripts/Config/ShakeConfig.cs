using UnityEngine;

[CreateAssetMenu(fileName = "ShakeConfig", menuName = "Create Config/Shake Config")]
public class ShakeConfig : ScriptableObject
{
    public float ShakeAmplitude;
    public float ShakeFrequency;
}
