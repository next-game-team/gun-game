using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _deathScreen;
    
    [SerializeField, ReadOnly]
    private bool _isPause = false;
    public bool IsPause => _isPause;

    private Liveble _playerLiveble;

    private void Awake()
    {
        _playerLiveble = GameObject.FindGameObjectWithTag("Player").GetComponent<Liveble>(); //How to find a player by another method?
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

    private void Update()
    {
        UpdateHealthPoint();
    }

    private void UpdateHealthPoint()
    {
        var hp = _playerLiveble.CurrentHp;
        if(hp <= 0)
        {
            PlayerDies();
        }
    }

    private void PlayerDies()
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
