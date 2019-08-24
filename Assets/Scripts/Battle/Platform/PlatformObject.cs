using UnityEngine;

[RequireComponent(typeof(PlatformEnterResolver))]
public class PlatformObject : PlaceObject<Platform, PlatformType>
{
    [SerializeField] private PlatformEnterResolver _enterResolver;
    
    public override void ResolveEntering()
    {
        _enterResolver.Resolve(CurrentPlace);
    }
}
