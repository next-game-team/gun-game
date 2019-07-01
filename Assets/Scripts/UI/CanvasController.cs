using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _deathScreen;
    [SerializeField] private ControlTutorial _controlTutorial;

    public GameObject PausePanel => _pausePanel;
    public GameObject DeathScreen => _deathScreen;
    public ControlTutorial ControlTutorial => _controlTutorial;
}
