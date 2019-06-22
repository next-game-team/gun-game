public class ResumeAction : ButtonAction
{
    public override void Action()
    {
        GameManager.Instance.ResumeGame();
    }
}