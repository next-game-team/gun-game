public class CommonDieInPool : Dieble
{
    public Pool Pool { get; set; }
    
    public override void Die()
    {
        Pool.ReturnObject(gameObject);
        base.Die();
    }
}