using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUtils {
    
    public static bool IsObjectInCamera(Camera camera, Transform cameraTransform, Vector2 objectPosition)
    {
        float pixelHeight = camera.pixelHeight;
        Vector2 cameraTop = camera.ScreenToWorldPoint(new Vector2(0, pixelHeight));
        float height = cameraTop.y - cameraTransform.position.y;

        if (objectPosition.y < cameraTop.y && objectPosition.y > cameraTransform.position.y - height)
        {
            return true;
        }
        else
            return false;
    }

    public static bool IsObjectInCamera(Camera camera, Transform cameraTransform, Vector2 objectPosition, float objectSizeY)
    {
        float pixelHeight = camera.pixelHeight;
        Vector2 cameraTop = camera.ScreenToWorldPoint(new Vector2(0, pixelHeight));
        float height = cameraTop.y - cameraTransform.position.y;

        if (objectPosition.y - objectSizeY < cameraTop.y && objectPosition.y + objectSizeY > cameraTransform.position.y - height)
        {
            return true;
        }
        else
            return false;
    }

    public static bool IsObjectDownerCamera(Camera camera, Transform cameraTransform, Vector2 objectPosition)
    {

        float pixelHeight = camera.pixelHeight;
        Vector2 cameraTop = camera.ScreenToWorldPoint(new Vector2(0, pixelHeight));
        float height = cameraTop.y - cameraTransform.position.y;

        return objectPosition.y < cameraTransform.position.y - height;

    }
}
