using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByKeyController : MoveController
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveCallEvent.Invoke(DirectionEnum.UP);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveCallEvent.Invoke(DirectionEnum.DOWN);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveCallEvent.Invoke(DirectionEnum.LEFT);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveCallEvent.Invoke(DirectionEnum.RIGHT);
        }
    }
}
