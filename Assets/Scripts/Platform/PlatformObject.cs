using UnityEngine;

public class PlatformObject : MonoBehaviour
{

    [SerializeField, ReadOnly]
    private Platform _currentPlatform;

    [SerializeField] 
    private Transform _objectBottomPosition;
    
    public Transform ObjectBottomPosition
    {
        get { return _objectBottomPosition; }
        set { _objectBottomPosition = value; }
    }

    public Platform CurrentPlatform
    {
        get { return _currentPlatform; }
        set { _currentPlatform = value; }
    }

    private void OnValidate()
    {
        ObjectBottomPosition = GameObjectUtils.GetChildrenWithTag(gameObject, TagEnum.PlatformObjectBottom).transform;
    }

}
