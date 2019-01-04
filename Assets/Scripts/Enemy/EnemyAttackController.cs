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
        if(Physics2D.Raycast(_shootPoint.position, Vector3.up, _raycastLength, _player))
        {
            return true;
        } else {
            return false;
        }
    }
}
