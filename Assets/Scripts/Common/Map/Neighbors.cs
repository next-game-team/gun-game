using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[Serializable]
public class Neighbors<T>
{
    public List<T> List()
    {
        return FullList().FindAll(elem => elem != null);
    }

    public List<T> FullList()
    {
        return new List<T>() {Left, Right, Top, Bottom};
    }
    
    [SerializeField]
    private T _left;
    public T Left => _left;

    [SerializeField]
    private T _right;
    public T Right => _right;

    [SerializeField]
    private T _top;
    public T Top => _top;
    
    [SerializeField]
    private T _bottom;
    public T Bottom => _bottom;

    public Dictionary<DirectionEnum, T> DirectionDictionary { get; }

    public Neighbors()
    {
        DirectionDictionary = new Dictionary<DirectionEnum, T>()
        {
            {DirectionEnum.LEFT, default(T)},
            {DirectionEnum.RIGHT, default(T)},
            {DirectionEnum.UP, default(T)},
            {DirectionEnum.DOWN, default(T)}
        };
    }
    
    public Neighbors(T left, T right, T top, T bottom)
    {
        _left = left;
        _right = right;
        _top = top;
        _bottom = bottom;
        DirectionDictionary = new Dictionary<DirectionEnum, T>()
        {
            {DirectionEnum.LEFT, _left},
            {DirectionEnum.RIGHT, _right},
            {DirectionEnum.UP, _top},
            {DirectionEnum.DOWN, _bottom}
        };
    }

    public void SetNeighbor(DirectionEnum direction, T neighbor)
    {
        switch (direction)
        {
            case DirectionEnum.LEFT :
                _left = neighbor;
                break;
            case DirectionEnum.RIGHT :
                _right = neighbor;
                break;
            case DirectionEnum.UP :
                _top = neighbor;
                break;
            case DirectionEnum.DOWN :
                _bottom = neighbor;
                break;
            default:
                Debug.LogWarning("Neighbor without direction");
                break;
        }
        DirectionDictionary[direction] = neighbor;
    }
}