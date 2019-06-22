using UnityEngine;

[RequireComponent(typeof(PlatformObjectPosition))]
public class CollectableObject : MonoBehaviour
{
    [SerializeField] 
    private CollectableType _type;

    public CollectableType Type
    {
        get { return _type; }
        set { _type = value; }
    }
    
    private PlatformObjectPosition _platformObjectPosition;

    public virtual void Destroy()
    {
        PoolManager.Instance.CollectablePool.ReturnObject(gameObject);
    }

    public void SetOnPlatform(Platform platform)
    {
        transform.position = _platformObjectPosition.GetPositionForPlatform(platform);
    }

    private void Awake()
    {
        _platformObjectPosition = GetComponent<PlatformObjectPosition>();
    }
}