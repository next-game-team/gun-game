using UnityEngine;

public class GunRayController : MonoBehaviour
{
    private LineRenderer _renderer;
    void Awake()
    {
        _renderer = GetComponentInChildren<LineRenderer>();
    }


    public void TurnOn()
    {
        _renderer.enabled = true;
    }
    
    public void TurnOff()
    {
        _renderer.enabled = false;
    }
}
