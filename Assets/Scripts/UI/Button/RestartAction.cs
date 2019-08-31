using UnityEngine;

public class RestartAction : ButtonAction
{
    [SerializeField] private int _sceneIndex;
    
    public override void Action()
    {
        BattleGameManager.Instance.RestartGame(_sceneIndex);
    }
}