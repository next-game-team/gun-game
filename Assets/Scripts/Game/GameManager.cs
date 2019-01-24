using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _deathScreen;
    
    [SerializeField, ReadOnly]
    private bool _isPause = false;
    public bool IsPause => _isPause;
    
    [SerializeField, ReadOnly] 
    private float _currentTimeScale;

    private GameObject _player;
    private Liveble _playerLiveble;
    private Dieble _playerDieble;
    private PlayerAttackManager _playerAttackManager;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerLiveble = _player.GetComponent<Liveble>();
        _playerLiveble.OnDieEvent += OnPlayerDeath; // Subscribe on player death event
        _playerAttackManager = _player.GetComponent<PlayerAttackManager>();
    }

    private void Start()
    {
        SetTimeScale(1);
    }

    public void SetTimeScale(float timeScale)
    {
        _currentTimeScale = timeScale;

        // Change time scale value if now game isn't paused
        if (!_isPause)
        {
            Time.timeScale = timeScale;
        }
    }

    public void PauseGame()
    {
        PauseTime();
        _pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        ResumeTime();
        _pausePanel.SetActive(false);
    }

    public void RestartGame(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    private void OnPlayerDeath(Liveble liveble)
    {
        PauseTime();
        _deathScreen.SetActive(true);
    }

    public void OnContinueButtonClicked() //Add HP
    {
        ResumeTime();
        _playerLiveble.InitHp();
        _deathScreen.SetActive(false);
    }

    private void PauseTime()
    {
        _isPause = true;
        Time.timeScale = 0;
        
        // Cancel player attack
        if (_playerAttackManager.IsInAttack)
        {
            Debug.Log("Cancel player attack on pausing time");
            _playerAttackManager.CancelAttack();
        }
    }

    private void ResumeTime()
    {
        _isPause = false;
        Time.timeScale = _currentTimeScale;
    }
}
