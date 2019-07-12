using UnityEngine;

public class AbstractPlace<T> : MonoBehaviour where T : AbstractPlace<T>
{
    [SerializeField, ReadOnly] 
    private Neighbors<T> _neighbors = new Neighbors<T>();
    
    public Neighbors<T> Neighbors
    {
        get { return _neighbors; }
        set { _neighbors = value; }
    }

    [SerializeField] private SidePoints _sidePoints;

    public SidePoints SidePoints => _sidePoints;
    
}