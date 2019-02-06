using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CommonMoveController : MoveController, IBeginDragHandler, IEndDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {    
        if (GameManager.Instance.IsPause) return;

        TouchManager.Instance.IsInDrag = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (GameManager.Instance.IsPause) return;
        
        TouchManager.Instance.IsInDrag = false;
        
        // Check move direction
        if (eventData.delta.x > 0)
        {
            MoveCallEvent.Invoke(DirectionEnum.RIGHT);
        } 
        else if (eventData.delta.x < 0)
        {
            MoveCallEvent.Invoke(DirectionEnum.LEFT);
        } 
        else if (eventData.delta.y > 0)
        {
            MoveCallEvent.Invoke(DirectionEnum.UP);
        } 
        else if (eventData.delta.y < 0)
        {
            MoveCallEvent.Invoke(DirectionEnum.DOWN);
        }
    }
    
    protected override void CheckInput()
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
