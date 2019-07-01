using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [Header("Current Game state")]
    [SerializeField, ReadOnly]
    private bool _isPause = false;
    public bool IsPause => _isPause;
    
    [SerializeField, ReadOnly] 
    private float _currentTimeScale;

    private Liveble _playerLiveble;
    private Dieble _playerDieble;
    private PlayerAttackManager _playerAttackManager;

    private void Awake()
    {
        _playerLiveble = GameObjectOnSceneManager.Instance.Player.GetComponent<Liveble>();
        _playerLiveble.OnDieEvent += OnPlayerDeath; // Subscribe on player death event
        _playerAttackManager = GameObjectOnSceneManager.Instance.Player.GetComponent<PlayerAttackManager>();
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
        GameObjectOnSceneManager.Instance.CanvasController.PausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        ResumeTime();
        GameObjectOnSceneManager.Instance.CanvasController.PausePanel.SetActive(false);
    }

    public void RestartGame(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void OnPlayerDeath(Liveble liveble)
    {
        PauseTime();
        GameObjectOnSceneManager.Instance.CanvasController.DeathScreen.SetActive(true);
    }

    public void ContinueGame() //Add HP
    {
        ResumeTime();
        _playerLiveble.InitHp();
        GameObjectOnSceneManager.Instance.CanvasController.DeathScreen.SetActive(false);
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
