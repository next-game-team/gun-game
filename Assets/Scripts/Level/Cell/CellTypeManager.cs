using UnityEngine;

public class CellTypeManager : Singleton<CellTypeManager>
{
    [SerializeField] 
    private CellTypeIconDictionary _typeIconDictionary;
    
    public CellTypeIconDictionary TypeIconDictionary => _typeIconDictionary;
}
