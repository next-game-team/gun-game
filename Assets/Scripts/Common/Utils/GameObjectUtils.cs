using System.Linq;
using UnityEngine;

public class GameObjectUtils
{
    public static GameObject GetChildrenWithTag(GameObject gameObject, TagEnum tag)
    {
        return gameObject.GetComponentsInChildren<GameObject>()
            .FirstOrDefault(children => TagUtils.CompareGameObjectTag(children, tag));
    }  
}