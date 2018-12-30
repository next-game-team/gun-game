using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackByTouchController : AttackController
{
    void Update() 
    {
        if(Input.touchCount > 0) //to change the logic
        {
            AttackEvent.Invoke();
        }
    }
}
