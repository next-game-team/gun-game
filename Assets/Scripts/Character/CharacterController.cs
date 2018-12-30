using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlatformObject))]
[RequireComponent(typeof(MoveController))]
[RequireComponent(typeof(AttackController))]
public class CharacterController : MonoBehaviour
{
    private PlatformObject _platformObject;
    private MoveController _moveController;
    private AttackController _attackController;
    
    // Start is called before the first frame update
    private void Awake()
    {
        _platformObject = GetComponent<PlatformObject>();
        
        _moveController = GetComponent<MoveController>();
        _moveController.MoveEvent.AddListener(OnMoveEvent);
        
        _attackController = GetComponent<AttackController>();
        _attackController.AttackEvent.AddListener(OnAttackEvent);
    }

    private void OnMoveEvent(DirectionEnum directionEnum)
    {
        BetweenPlatformMover.MoveTo(_platformObject, directionEnum);
    }

    private void OnAttackEvent()
    {
        
    }
}
