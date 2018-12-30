using UnityEngine;
using UnityEngine.Events;

public class AttackEvent : UnityEvent {}

public abstract class AttackController : MonoBehaviour
{
    public AttackEvent AttackEvent { get; } = new AttackEvent(); 
}
