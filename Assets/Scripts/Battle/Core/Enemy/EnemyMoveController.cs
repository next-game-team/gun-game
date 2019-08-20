using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveController : MoveController
{
    private PlatformObject _platformObject;
    private CharacterMoveManager _moveManager;
    private Liveble _liveble;

    private void Awake()
    {
        _platformObject = GetComponent<PlatformObject>();
        _moveManager = GetComponent<CharacterMoveManager>();
        _liveble = GetComponent<Liveble>();
    }

    protected override void CheckInput()
    {
        if (_moveManager.IsMoveCooldown || !_liveble.IsAlive()) return;
        
        MoveCallEvent.Invoke(_platformObject.CurrentPlace.GetRandomFreeNeighborDirection());
    }
}
