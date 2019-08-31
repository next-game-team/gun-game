using UnityEngine;

public class PauseController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (BattleGameManager.Instance.IsPause)
            {
                BattleGameManager.Instance.ResumeGame();
            }
            else
            {
                BattleGameManager.Instance.PauseGame();
            }
        }
    }
}