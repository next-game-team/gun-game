using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Liveble))]
public class HpLampController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _lamps;
    
    private Liveble _liveble;
    
    // Start is called before the first frame update
    void Start()
    {
        _liveble = GetComponent<Liveble>();
        _liveble.OnHpUpdateEvent += OnHpUpdate;
    }

    private void OnHpUpdate(Liveble liveble, int hpDelta)
    {
        if (hpDelta > 0)
        {
            IncreaseLamps(hpDelta);
        }
        else
        {
            DecreaseLamps(-hpDelta);
        }
    }

    private void IncreaseLamps(int hpDelta)
    {
        for (var lampIndex = _liveble.CurrentHp + 1;
            lampIndex <= _liveble.CurrentHp + hpDelta; 
            lampIndex++)
        {
            _lamps[lampIndex].SetActive(true);
        }
    }
    
    private void DecreaseLamps(int hpDelta)
    {
        for (var lampIndex = _liveble.CurrentHp;
            lampIndex > _liveble.CurrentHp - hpDelta; 
            lampIndex--)
        {
            _lamps[lampIndex].SetActive(false);
        }
    }
}
