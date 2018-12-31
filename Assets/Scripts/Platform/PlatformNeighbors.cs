using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlatformNeighbors
{
    public List<Platform> List { get; }
    
    [SerializeField]
    private Platform _left;
    public Platform Left => _left;

    [SerializeField]
    private Platform _right;
    public Platform Right => _right;

    [SerializeField]
    private Platform _top;
    public Platform Top => _top;
    
    [SerializeField]
    private Platform _bottom;
    public Platform Bottom => _bottom;

    public PlatformNeighbors(Platform left, Platform right, Platform top, Platform bottom)
    {
        _left = left;
        _right = right;
        _top = top;
        _bottom = bottom;
        List = new List<Platform>() {Left, Right, Top, Bottom};
    }
}