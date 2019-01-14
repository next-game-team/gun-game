using UnityEngine;

public class LevelTestGeneration : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LevelManager.Instance.GenerateNextLevel();
            LevelManager.Instance.CurrentLevel.StartLevel();
        }
    }
}