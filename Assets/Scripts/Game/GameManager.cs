using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _deathScreen;
    
    [SerializeField, ReadOnly]
    private bool _isPause = false;
    public bool IsPause => _isPause;

    private GameObject _player;
    private Liveble _playerLiveble;
    private Dieble _playerDieble;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerLiveble = _player.GetComponent<Liveble>();
        
        // Subscribe on death event
        _playerDieble = _player.GetComponent<Dieble>();
        _playerDieble.OnDieEvent += OnPlayerDeath;
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        _isPause = true;
        Time.timeScale = 0;
        _pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        _isPause = false;
        Time.timeScale = 1;
        _pausePanel.SetActive(false);
    }

    public void RestartGame(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    private void OnPlayerDeath(Dieble dieble)
    {
        Time.timeScale = 0;
        _deathScreen.SetActive(true);
    }

    public void OnContinueButtonClicked() //Add HP
    {
        _playerLiveble.InitHp();
        Time.timeScale = 1;
        _deathScreen.SetActive(false);
    }
}
