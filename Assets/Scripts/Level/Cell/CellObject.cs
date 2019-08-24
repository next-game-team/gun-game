using UnityEngine;

[RequireComponent(typeof(CellEnterResolver))]
public class CellObject : PlaceObject<Cell, CellType>
{
    [SerializeField]
    private CellEnterResolver _enterResolver;
    
    public override void ResolveEntering()
    {
        _enterResolver.Resolve(CurrentPlace);
    }
}
