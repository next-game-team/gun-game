using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(ICollectableController))]
public class PlatformObject : MonoBehaviour
{

    [SerializeField] 
    private float _betweenPlatformMoveDuration = 0.5f;

    public float BetweenPlatformMoveDuration
    {
        get { return _betweenPlatformMoveDuration; }
        set { _betweenPlatformMoveDuration = value; }
    } 
    
    public ICollectableController CollectableController { get; private set; }
    
    [SerializeField, ReadOnly]
    private Platform _currentPlatform;

    public Platform CurrentPlatform
    {
        get { return _currentPlatform; }
        set { _currentPlatform = value; }
    }

    private PlatformObjectPosition _platformObjectPosition;

    public void SetOnPlatform(Platform platform)
    {
        transform.position = _platformObjectPosition.GetPositionForPlatform(platform);
    }
    
    public void MoveToPlatform(Platform platform)
    {
        transform.DOMove(_platformObjectPosition.GetPositionForPlatform(platform), 
            BetweenPlatformMoveDuration);
    }

    private void Awake()
    {
        CollectableController = GetComponent<ICollectableController>();
        _platformObjectPosition = GetComponent<PlatformObjectPosition>();
    }

}
