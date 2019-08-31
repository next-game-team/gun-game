public class ContinueAction : ButtonAction
{
    public override void Action()
    {
        BattleGameManager.Instance.ContinueGame();
    }
}