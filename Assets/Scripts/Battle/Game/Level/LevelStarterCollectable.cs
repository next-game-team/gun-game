public class LevelStarterCollectable : CollectableObject
{
    public override void Destroy()
    {
        gameObject.SetActive(false);
    }
}