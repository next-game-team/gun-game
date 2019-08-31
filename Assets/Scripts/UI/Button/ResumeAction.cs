public class ResumeAction : ButtonAction
{
    public override void Action()
    {
        BattleGameManager.Instance.ResumeGame();
    }
}