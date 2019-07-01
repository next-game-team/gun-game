public class ContinueAction : ButtonAction
{
    public override void Action()
    {
        GameManager.Instance.ContinueGame();
    }
}