using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveController : MoveController
{
    private PlatformObject _platformObject;
    private CharacterMoveManager _moveManager;

    private void Awake()
    {
        _platformObject = GetComponent<PlatformObject>();
        _moveManager = GetComponent<CharacterMoveManager>();
    }

    protected override void CheckInput()
    {
        if (_moveManager.IsMoveCooldown) return;
        
        MoveCallEvent.Invoke(_platformObject.CurrentPlatform.GetRandomFreeNeighborDirection());
    }
}
