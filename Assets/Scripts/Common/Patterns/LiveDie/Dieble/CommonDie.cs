public class CommonDie : Dieble {
    
    public override void Die()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
    
}
