public class PauseAction : ButtonAction
{
    public override void Action()
    {
        GameManager.Instance.PauseGame();
    }
}