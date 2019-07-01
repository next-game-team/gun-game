public class ExitAction : ButtonAction
{
    public override void Action()
    {
        GameManager.Instance.ExitGame();
    }
}