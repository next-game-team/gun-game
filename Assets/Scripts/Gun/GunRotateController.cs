using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotateController : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 1;

    private float _currentAngle = 0;
    private const float ANGLE_SPEED_CONST = 1; 
    
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.AngleAxis(_currentAngle, Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        _currentAngle++;
        transform.rotation = Quaternion.AngleAxis(_currentAngle * ANGLE_SPEED_CONST * _rotationSpeed, Vector3.forward);
    }
}
