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

    public static bool CompareLayerWithMask(GameObject gameObject, LayerMask mask)
    {
        return ((1 << gameObject.layer) & mask) != 0;
    }
}