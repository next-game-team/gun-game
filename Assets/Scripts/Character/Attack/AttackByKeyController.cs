using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackByKeyController : AttackController
{
    
    protected override void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            AttackEvent.Invoke();
        }
    }
}
