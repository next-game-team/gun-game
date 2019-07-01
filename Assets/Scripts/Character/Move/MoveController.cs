using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveEvent : UnityEvent<DirectionEnum> {}

public abstract class MoveController : InputController
{
    public MoveEvent MoveCallEvent { get; } = new MoveEvent(); 
}
