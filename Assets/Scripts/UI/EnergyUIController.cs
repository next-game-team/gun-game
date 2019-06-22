using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SeparableImage))]
public class EnergyUIController : MonoBehaviour
{
    private SeparableImage _img;
    private PlayerAttackWithEnergyManager _playerAttackManager;


    void Awake()
    {
        _playerAttackManager = GameObjectOnSceneManager.Instance.Player
            .GetComponent<PlayerAttackWithEnergyManager>();
        _img = GetComponent<SeparableImage>();
        _img.Clean();
    }

    private void Start()
    {
        _playerAttackManager.OnEnergyIncrease.AddListener(OnEnergyIncrease);
        _playerAttackManager.OnEnergyDecrease.AddListener(OnEnergyDecrease);
        _img.Init(_playerAttackManager.MaxEnergyCount);
    }

    private void OnEnergyIncrease(int value)
    {
        _img.Increase(value);
    }

    private void OnEnergyDecrease(int value)
    {
        _img.Decrease(value);
    }
}
