using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : AttackController
{
    [SerializeField] private Transform _shootPoint; //change
    [SerializeField] private float _raycastLength;
    [SerializeField] private LayerMask _player;

    void Update()
    {   
        if(FindPlayer())
        {
            AttackEvent.Invoke();
        }
    }

    private bool FindPlayer()
    {
        var direction = _shootPoint.position - transform.position;

        if(Physics2D.Raycast(_shootPoint.position, direction, _raycastLength, _player))
        {
            return true;
        } else {
            return false;
        }
    }
}
