using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveController))]
[RequireComponent(typeof(PlatformObject))]
public class PlayerController : MonoBehaviour
{
    private MoveController _moveController;
    private PlatformObject _platformObject;
    
    // Start is called before the first frame update
    void Awake()
    {
        _moveController = GetComponent<MoveController>();
        _moveController.MoveEvent.AddListener(OnMoveEvent);

        _platformObject = GetComponent<PlatformObject>();
    }

    private void OnMoveEvent(DirectionEnum directionEnum)
    {
        BetweenPlatformMover.MoveTo(_platformObject, directionEnum);
    }
}
