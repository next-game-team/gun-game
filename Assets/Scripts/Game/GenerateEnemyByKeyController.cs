using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemyByKeyController : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            EnemyGenerator.Instance.GenerateRandomEnemyOnRandomPosition();
        }
    }
}
