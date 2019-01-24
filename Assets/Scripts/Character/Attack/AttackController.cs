using UnityEngine.Events;

public class AttackEvent : UnityEvent {}

public abstract class AttackController : InputController
{
    public AttackEvent AttackEvent { get; } = new AttackEvent(); 
}
