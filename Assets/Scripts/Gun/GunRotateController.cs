using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotateController : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 1;
    [SerializeField, ReadOnly]
    private bool _isLeftRotated = true;
    
    private float _currentAngle = 0;

    public void ChangeRotation()
    {
        _isLeftRotated = !_isLeftRotated;
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        transform.rotation = Quaternion.AngleAxis(_currentAngle, Vector3.forward);
    }

    // Update is called once per frame
    private void Update()
    {
        _currentAngle += (_isLeftRotated ? 1 : -1) * _rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(_currentAngle, Vector3.forward);
    }
}
