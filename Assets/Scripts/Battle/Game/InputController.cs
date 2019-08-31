using UnityEngine;

public abstract class InputController : MonoBehaviour
{
    private void Update()
    {
        if (BattleGameManager.Instance.IsPause) return;
        
        CheckInput();
    }

    protected abstract void CheckInput();
}