using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject _pausePanel;
    
    [SerializeField, ReadOnly]
    private bool _isPause = false;
    public bool IsPause => _isPause;

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
}
