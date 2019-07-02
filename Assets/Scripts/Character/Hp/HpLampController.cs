using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Liveble))]
public class HpLampController : MonoBehaviour
{
    [SerializeField]
    private HpLampPositionController _hpLampPositionController;
    
    private Liveble _liveble;
    
    // Start is called before the first frame update
    void Start()
    {
        _liveble = GetComponent<Liveble>();
        _liveble.OnHpUpdateEvent += OnHpUpdate;
        
        InitLamps();
    }

    public void InitLamps()
    {
        if(_hpLampPositionController != null) Destroy(_hpLampPositionController.gameObject);
        var hpLampPositionPrefab = GlobalCharacterManager.Instance.GetHpLampPositionPrefab(_liveble.HpConfig.Hp);
        _hpLampPositionController = Instantiate(hpLampPositionPrefab, transform)
            .GetComponent<HpLampPositionController>();
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
            _hpLampPositionController.Lamps[lampIndex].SetActive(true);
        }
    }
    
    private void DecreaseLamps(int hpDelta)
    {
        for (var lampIndex = _liveble.CurrentHp;
            lampIndex > _liveble.CurrentHp - hpDelta; 
            lampIndex--)
        {
            _hpLampPositionController.Lamps[lampIndex].SetActive(false);
        }
    }
}
