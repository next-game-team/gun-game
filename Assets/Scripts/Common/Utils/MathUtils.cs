using UnityEngine;

public static class MathUtils {

    public static float GetPointOnTargetLookAngle(Vector3 pointPosition, Vector3 lookTargetPosition)
    {
        var lookPos = lookTargetPosition - pointPosition;
        return Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
    }
}