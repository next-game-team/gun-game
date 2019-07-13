using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : Dieble
{
    protected override void Die(Liveble liveble)
    {
        Debug.Log("Player died. Init HP again");
    }
}
