public class PauseAction : ButtonAction
{
    public override void Action()
    {
        BattleGameManager.Instance.PauseGame();
    }
}