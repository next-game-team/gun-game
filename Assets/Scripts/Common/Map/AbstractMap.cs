using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMap<T> : Singleton<T> where T : Singleton<T>
{
    public void CleanChildren()
    {
        var children = new List<GameObject>();
        foreach (Transform child in transform) children.Add(child.gameObject);
        children.ForEach(DestroyImmediate);
    }    
}