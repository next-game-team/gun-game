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

    private bool _isCantMove = false;
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
        if(_isCantMove) return;

        var moveResult = BetweenPlatformMover.MoveTo(_platformObject, directionEnum);
        if (moveResult == false) return;
        
        _isCantMove = true;
        _currentCooldownTime = _moveConfig.CooldownTime;    
    }

    private void OnAttackEvent()
    {
        if (_gun == null) return; 
        
        _gun.Shoot();
    }

    private void Update()
    {
        if (!_isCantMove) return;

        if (_isCantMove && _currentCooldownTime > 0)
        {
            _currentCooldownTime -= Time.deltaTime;
        }
        else
        {
            _isCantMove = false;
        }

    }
}
