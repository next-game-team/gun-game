using UnityEngine;

public class PlatformObjectPosition : MonoBehaviour
{
    [SerializeField, ReadOnly] 
    private Transform _objectBottomPosition;
    
    public Transform ObjectBottomPosition
    {
        get { return _objectBottomPosition; }
        set { _objectBottomPosition = value; }
    }
    
    public Vector3 VectorFromBottomToCenter { get; set; }

    public Vector3 GetPositionForPlatform(Platform platform)
    {
        return VectorFromBottomToCenter + platform.CenterOfTopBound.position;
    }
    
    public void SetOnPlatform(Platform platform)
    {
        transform.position = GetPositionForPlatform(platform);
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