using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SidePoints
{
    [SerializeField]
    private Transform _left;
    public Transform Left => _left;
    
    [SerializeField]
    private Transform _right;
    public Transform Right => _right;
    
    [SerializeField]
    private Transform _top;
    public Transform Top => _top;
    
    [SerializeField]
    private Transform _bottom;
    public Transform Bottom => _bottom;

    public Dictionary<DirectionEnum, Transform> DirectionDictionary { get; private set; }

    public SidePoints()
    {
        Init();
    }

    public void Init()
    {
        DirectionDictionary = new Dictionary<DirectionEnum, Transform>()
        {
            {DirectionEnum.LEFT, _left},
            {DirectionEnum.RIGHT, _right},
            {DirectionEnum.UP, _top},
            {DirectionEnum.DOWN, _bottom}
        };
    }
}