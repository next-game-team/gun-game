using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveBySwipeController : MoveController, IBeginDragHandler, IDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (GameManager.Instance.IsPause) return;
        
        if(eventData.delta.x > 0)
        {
            MoveCallEvent.Invoke(DirectionEnum.RIGHT);
        } 
        else if(eventData.delta.x < 0)
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

    public void OnDrag(PointerEventData eventData)
    {
    }

    protected override void CheckInput()
    {
        
    }
}
