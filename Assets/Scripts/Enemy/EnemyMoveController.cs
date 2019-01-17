using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveController : MoveController
{
    private PlatformObject _platformObject;
    private CharacterController _characterController;

    private void Awake()
    {
        _platformObject = GetComponent<PlatformObject>();
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_characterController.IsMoveCooldown) return;
        
        MoveEvent.Invoke(_platformObject.CurrentPlatform.GetRandomFreeNeighborDirection());
    }


}
