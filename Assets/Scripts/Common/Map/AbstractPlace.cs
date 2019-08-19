using System;
using UnityEngine;

[Serializable]
public abstract class AbstractPlace<T> : MonoBehaviour where T : AbstractPlace<T>
{
    [SerializeField] private SidePoints _sidePoints;

    public SidePoints SidePoints => _sidePoints;
    
    private Neighbors<T> _neighbors = new Neighbors<T>();
    
    public Neighbors<T> Neighbors
    {
        get { return _neighbors; }
        set { _neighbors = value; }
    }

    private void Awake()
    {
        _sidePoints.Init();
    }
}