using System.Collections.Generic;
using UnityEngine;

public class GlobalCharacterManager : Singleton<GlobalCharacterManager>
{
    [SerializeField] private List<GameObject> _hpLampPositionList;

    public GameObject GetHpLampPositionPrefab(int hpCount)
    {
        if (hpCount >= _hpLampPositionList.Count)
        {
            Debug.LogError("HpCount is more than list size");
            return null;
        }

        if (_hpLampPositionList[hpCount] == null)
        {
            Debug.LogError("There is no hpLampPosition for this count size");
        }
        return _hpLampPositionList[hpCount];
    } 
}
