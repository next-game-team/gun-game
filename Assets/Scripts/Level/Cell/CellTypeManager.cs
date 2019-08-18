using UnityEngine;

public class CellTypeManager : Singleton<CellTypeManager>
{
    [SerializeField] 
    private CellTypeIconDictionary _typeIconDictionary = new CellTypeIconDictionary()
    {
        {CellType.Empty, null},
        {CellType.Enemy, null},
        {CellType.Generator, null},
        {CellType.Boss, null},
        {CellType.Teleport, null}
    };
    
    public CellTypeIconDictionary TypeIconDictionary => _typeIconDictionary;
}
