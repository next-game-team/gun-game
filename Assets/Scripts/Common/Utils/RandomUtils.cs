using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomUtils {

    public static bool IsRandomSaysTrue(float probability)
    {
        return Random.value <= probability;
    }

}
