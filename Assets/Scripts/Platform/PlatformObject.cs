using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformObject : MonoBehaviour
{

    [SerializeField, ReadOnly]
    private Platform _currentPlatform;

    [SerializeField] 
    private Transform _objectBottomPosition;

    public Transform ObjectBottomPosition => _objectBottomPosition;

    public Platform CurrentPlatform => _currentPlatform;

    private void Awake()
    {
        _objectBottomPosition = GameObjectUtils.GetChildrenWithTag(gameObject, TagEnum.PlatformObjectBottom).transform;
    }

}
