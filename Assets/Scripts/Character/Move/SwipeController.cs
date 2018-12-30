using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeController : MoveController, IBeginDragHandler, IDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(eventData.delta.x > 0)
        {
            MoveEvent.Invoke(DirectionEnum.RIGHT);
        } else if(eventData.delta.x < 0)
        {
            MoveEvent.Invoke(DirectionEnum.LEFT);
        } else if (eventData.delta.y > 0)
        {
            MoveEvent.Invoke(DirectionEnum.UP);
        } else if (eventData.delta.y < 0)
        {
            MoveEvent.Invoke(DirectionEnum.DOWN);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
    }

}
