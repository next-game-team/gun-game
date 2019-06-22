using UnityEngine;

public class PlayerStartPositionController : MonoBehaviour
{
    [SerializeField]
    private Platform _startPlatform;
 
    private PlatformObject _player;

    private void Start()
    {
        _player = GameObjectOnSceneManager.Instance.Player.GetComponent<PlatformObject>();
        if (_startPlatform == null)
        {
            Debug.LogWarning("PlayerStartPositionController doesn't have Start Platform");
            return;
        }

        _startPlatform.SetPlatformObject(_player);
        _player.SetOnPlatform(_startPlatform);
    }
}
