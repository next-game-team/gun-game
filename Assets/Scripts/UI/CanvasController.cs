using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _deathScreen;

    public GameObject PausePanel => _pausePanel;
    public GameObject DeathScreen => _deathScreen;
}
