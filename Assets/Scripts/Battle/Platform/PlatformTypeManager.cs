using UnityEngine;

public class PlatformTypeManager : Singleton<PlatformTypeManager>
{
    [SerializeField] 
    private PlatformTypeIconDictionary _typeIconDictionary = new PlatformTypeIconDictionary()
    {
        {PlatformType.Empty, null},
        {PlatformType.Energy, null},
        {PlatformType.Start, null}
    };
    
    public PlatformTypeIconDictionary TypeIconDictionary => _typeIconDictionary;
}
