using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private bool _isPause = false;
    [SerializeField] private GameObject _pausePanel;

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        _isPause = !_isPause;

        if(_isPause)
        {
            Time.timeScale = 0;
            _pausePanel.SetActive(_isPause);
        } else {
            Time.timeScale = 1;
            _pausePanel.SetActive(_isPause);
        }
    }

    public void RestartGame(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        _isPause = false;
        _pausePanel.SetActive(false);
    }
}
