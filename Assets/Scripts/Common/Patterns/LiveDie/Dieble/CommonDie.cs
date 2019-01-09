public class CommonDie : Dieble {
    
    public override void Die()
    {
        base.Die();
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
    
}
