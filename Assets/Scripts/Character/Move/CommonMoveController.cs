using UnityEngine;

public class CommonMoveController : MoveController
{   
    protected override void CheckInput()
    {
        CheckKeyInput();
        CheckTouchInput();
    }

    private void CheckTouchInput()
    {
        if (TouchManager.Instance.MoveTouchState == TouchManager.TouchState.TouchEnd)
        {
            MoveCallEvent.Invoke(TouchManager.Instance.MoveDirection);
            TouchManager.Instance.MoveTouchState = TouchManager.TouchState.Idle;
        }
    }

    private void CheckKeyInput()
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
