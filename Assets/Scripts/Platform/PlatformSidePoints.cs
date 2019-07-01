using System;
using UnityEngine;

[Serializable]
public class PlatformSidePoints
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
    
    
}