using UnityEngine;
using UnityEngine.SceneManagement;

public class AbstractGameManager<T> : Singleton<T> where T : AbstractGameManager<T>
{
    [Header("Current Game state")]
    [SerializeField, ReadOnly]
    private bool _isPause;
    public bool IsPause
    {
        get { return _isPause; }
        set { _isPause = value; }
    }

    [SerializeField, ReadOnly] 
    private float _currentTimeScale;

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

    protected virtual void PauseTime()
    {
        _isPause = true;
        Time.timeScale = 0;
    }

    protected void ResumeTime()
    {
        _isPause = false;
        Time.timeScale = _currentTimeScale;
    }
}
