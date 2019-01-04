using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class RandomUtils {

    public static bool IsRandomSaysTrue(float probability)
    {
        return Random.value <= probability;
    }

    public static T GetRandomObjectFromList<T>(List<T> list)
    {
        return list.Count == 0 ? default(T) : list[Random.Range(0, list.Count)];
    }

}
