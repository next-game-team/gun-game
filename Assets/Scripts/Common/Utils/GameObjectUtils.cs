using System.Linq;
using UnityEngine;

public class GameObjectUtils
{
    public static GameObject GetChildrenWithTag(GameObject gameObject, TagEnum tag)
    {
        foreach (Transform child in gameObject.transform)
        {
            if (TagUtils.CompareGameObjectTag(child.gameObject, tag))
            {
                return child.gameObject;
            }
        }

        return null;
    }  
}