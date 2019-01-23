using UnityEngine;
using UnityEngine.UI;

public class TimeRechargeUIController : MonoBehaviour
{
    private Image _img;
    private GameObject _player;
    private PlayerAttackWithTimeManager _timeManager;


    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _timeManager = _player.GetComponent<PlayerAttackWithTimeManager>();
        _img = GetComponent<Image>();
    }

    void Update()
    {
        _img.fillAmount = (_timeManager.CurrentTimeEnergy / _timeManager.AttackWithTimeConfig.TimeEnergyCapacity);
    }
}
