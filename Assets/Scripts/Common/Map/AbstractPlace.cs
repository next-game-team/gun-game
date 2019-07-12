using System;
using UnityEngine;

[Serializable]
public class AbstractPlace<T> : MonoBehaviour where T : AbstractPlace<T>
{
    [SerializeField] private SidePoints _sidePoints;

    public SidePoints SidePoints => _sidePoints;
    
}