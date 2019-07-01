using UnityEngine;

public class ControlTutorial : MonoBehaviour
{
    [SerializeField] private GameObject _swipeScreen;
    [SerializeField] private GameObject _attackScreen;

    public GameObject SwipeScreen => _swipeScreen;
    public GameObject AttackScreen => _attackScreen;
}