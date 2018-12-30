using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByKeyController : MoveController
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveEvent.Invoke(DirectionEnum.UP);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveEvent.Invoke(DirectionEnum.DOWN);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveEvent.Invoke(DirectionEnum.LEFT);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveEvent.Invoke(DirectionEnum.RIGHT);
        }
    }
}
