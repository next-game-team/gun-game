using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : Dieble
{
    public override void Die()
    {
        GetComponent<Liveble>().InitHp();
        Debug.Log("Player died. Init HP again");
    }
}
