using DG.Tweening;
using UnityEngine;

public class PlatformObject : MonoBehaviour
{

    [SerializeField] 
    private float _betweenPlatformMoveDuration = 0.5f;

    public float BetweenPlatformMoveDuration
    {
        get { return _betweenPlatformMoveDuration; }
        set { _betweenPlatformMoveDuration = value; }
    } 
    
    [SerializeField, ReadOnly]
    private Platform _currentPlatform;

    [SerializeField, ReadOnly] 
    private Transform _objectBottomPosition;
    
    public Transform ObjectBottomPosition
    {
        get { return _objectBottomPosition; }
        set { _objectBottomPosition = value; }
    }
    
    public Vector3 VectorFromBottomToCenter { get; set; }

    public Platform CurrentPlatform
    {
        get { return _currentPlatform; }
        set { _currentPlatform = value; }
    }

    public void SetOnPlatform(Platform platform)
    {
        transform.position = VectorFromBottomToCenter + platform.CenterOfTopBound.position;
    }

    public void MoveToPlatform(Platform platform)
    {
        transform.DOMove(VectorFromBottomToCenter + platform.CenterOfTopBound.position, 
            BetweenPlatformMoveDuration);
    }

    private void Awake()
    {
        Init();
    }

    private void OnValidate()
    {
        Init();
    }

    private void Init()
    {
        ObjectBottomPosition = GameObjectUtils.GetChildrenWithTag(gameObject, TagEnum.PlatformObjectBottom).transform;
        VectorFromBottomToCenter = transform.position - _objectBottomPosition.position;
    }

}
