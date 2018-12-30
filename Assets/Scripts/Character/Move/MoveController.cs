using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveEvent : UnityEvent<DirectionEnum> {}

public abstract class MoveController : MonoBehaviour
{
    public MoveEvent MoveEvent { get; } = new MoveEvent(); 
}
