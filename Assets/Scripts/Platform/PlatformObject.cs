using UnityEngine;

public class PlatformObject : MonoBehaviour
{

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
