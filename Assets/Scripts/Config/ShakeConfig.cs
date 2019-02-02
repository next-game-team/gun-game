using UnityEngine;

[CreateAssetMenu(fileName = "ShakeConfig", menuName = "Create Shake Config")]
public class ShakeConfig : ScriptableObject
{
    public float ShakeAmplitude;
    public float ShakeFrequency;
}
