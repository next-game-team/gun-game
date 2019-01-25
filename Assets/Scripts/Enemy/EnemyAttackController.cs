using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : AttackController
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _raycastLength;
    [SerializeField] private LayerMask _player;
    [SerializeField, Range(0, 1)] private float _shootProbability;

    private Liveble _liveble;

    private void Awake()
    {
        _liveble = GetComponent<Liveble>();
    }

    protected override void CheckInput()
    {
        if (_liveble.IsAlive() && FindPlayer())
        {
            AttackEvent.Invoke();
        }
    }

    private bool FindPlayer()
    {
        var direction = _shootPoint.position - transform.position;

        return Physics2D.Raycast(_shootPoint.position, direction, _raycastLength, _player)
            && RandomUtils.IsRandomSaysTrue(_shootProbability);
    }
}
