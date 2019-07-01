using UnityEngine;

public class RestartAction : ButtonAction
{
    [SerializeField] private int _sceneIndex;
    
    public override void Action()
    {
        GameManager.Instance.RestartGame(_sceneIndex);
    }
}