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

    [SerializeField]
    private Gun _gun;

    [SerializeField] private MoveConfig _moveConfig;

    private bool _isMoveCooldown;
    private float _currentCooldownTime;
    
    private void Awake()
    {
        _platformObject = GetComponent<PlatformObject>();
        
        _moveController = GetComponent<MoveController>();
        _moveController.MoveEvent.AddListener(OnMoveEvent);
        
        _attackController = GetComponent<AttackController>();
        _attackController.AttackEvent.AddListener(OnAttackEvent);

        if (_gun == null)
        {
            Debug.LogWarning("There is no gun on Character: " + gameObject.name);
        }
    }

    private void OnMoveEvent(DirectionEnum directionEnum)
    {
        if(_isMoveCooldown) return;

        var moveResult = BetweenPlatformMover.MoveTo(_platformObject, directionEnum);
        if (moveResult == false) return;
        
        _isMoveCooldown = true;
        _currentCooldownTime = _moveConfig.CooldownTime;    
    }

    private void OnAttackEvent()
    {
        if (_gun == null) return; 
        
        _gun.Shoot();
    }

    private void Update()
    {
        if (!_isMoveCooldown) return;

        if (_isMoveCooldown && _currentCooldownTime > 0)
        {
            _currentCooldownTime -= Time.deltaTime;
        }
        else
        {
            _isMoveCooldown = false;
        }

    }
}
