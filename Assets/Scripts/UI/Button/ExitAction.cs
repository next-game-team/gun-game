public class ExitAction : ButtonAction
{
    public override void Action()
    {
        BattleGameManager.Instance.ExitGame();
    }
}