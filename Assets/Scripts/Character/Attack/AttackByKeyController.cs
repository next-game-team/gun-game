using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackByKeyController : AttackController
{
    
    protected override void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) ||
            // Check if user tap on screen (1 touch) or tap while swiping (2 touches) 
            Input.touchCount > (TouchManager.Instance.IsInDrag ? 2 : 1)) 
        {
            AttackEvent.Invoke();
        }
    }
}
