using System;
using UnityEngine;

public class PlaceObjectPosition<T> : MonoBehaviour //where T : AbstractPlace<T>
{
    public Vector3 GetPosition(T place)
    {
        //return place.transform.position;
        throw new NotImplementedException();
    }
}
