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

    private Gun _gun;
    
    // Start is called before the first frame update
    private void Awake()
    {
        _platformObject = GetComponent<PlatformObject>();
        
        _moveController = GetComponent<MoveController>();
        _moveController.MoveEvent.AddListener(OnMoveEvent);
        
        _attackController = GetComponent<AttackController>();
        _attackController.AttackEvent.AddListener(OnAttackEvent);

        _gun = GameObjectUtils.GetChildrenWithTag(gameObject, TagEnum.Gun).GetComponent<Gun>();
        if (_gun == null)
        {
            Debug.LogError("There is no gun on Character: " + gameObject.name);
        }
    }

    private void OnMoveEvent(DirectionEnum directionEnum)
    {
        BetweenPlatformMover.MoveTo(_platformObject, directionEnum);
    }

    private void OnAttackEvent()
    {
        _gun.Shoot();
    }
}
