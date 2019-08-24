using UnityEngine;

public abstract class PlaceEnterResolver<T> : MonoBehaviour
{
    public abstract void Resolve(T place);
}