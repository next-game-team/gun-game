using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveController))]
public class PlayerController : MonoBehaviour
{
    private MoveController _moveController;
    
    // Start is called before the first frame update
    void Awake()
    {
        _moveController = GetComponent<MoveController>();
        _moveController.MoveEvent.AddListener(OnMoveEvent);
    }

    private void OnMoveEvent(DirectionEnum directionEnum)
    {
        
    }
}
