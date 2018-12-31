using UnityEngine;

public class PlayerStartPositionController : MonoBehaviour
{
    [SerializeField]
    private Platform _startPlatform;

    [SerializeField] 
    private PlatformObject _player;

    private void Awake()
    {
        if (_startPlatform == null || _player == null)
        {
            Debug.LogWarning("PlayerStartPositionController doesn't have objects");
            return;
        }

        _startPlatform.PlatformObject = _player;
        _player.transform.position = _startPlatform.CenterOfTopBound.position
                                            + _player.VectorFromBottomToCenter;
    }
}
