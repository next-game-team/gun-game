using System.Collections;
using UnityEngine;

public class GunRayController : MonoBehaviour
{
    [SerializeField]
    private float _animationWaitTime = 0.002f;
    
    [SerializeField]
    private float _animationSpeed = 0.3f;

    [SerializeField]
    private float _flashSize = 3f;
    
    private LineRenderer _lineRenderer;
    void Awake()
    {
        _lineRenderer = GetComponentInChildren<LineRenderer>();
    }


    public void TurnOn()
    {
        _lineRenderer.enabled = true;
        
    }
    
    public void TurnOff()
    {
        _lineRenderer.enabled = false;
    }

    public void ShootEffect()
    {
        StartCoroutine(ShootEffectCoroutine());
    }

    IEnumerator ShootEffectCoroutine()
    {
        var rayPreviousLastPosition = _lineRenderer.GetPosition(1);
        var rayCurrentLastPosition = Vector3.zero;
        _lineRenderer.SetPosition(1, rayCurrentLastPosition);
        _lineRenderer.widthMultiplier = 3f;
        for (float currentRaySize = 0; currentRaySize < _flashSize; currentRaySize += _animationSpeed)
        {
            rayCurrentLastPosition.y = currentRaySize;
            _lineRenderer.SetPosition(1, rayCurrentLastPosition);
            yield return new WaitForSeconds(_animationWaitTime);
        }
        
        _lineRenderer.widthMultiplier = 1f;
        _lineRenderer.SetPosition(1, rayPreviousLastPosition);
        TurnOff();
    } 
}
