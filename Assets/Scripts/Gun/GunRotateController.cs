using UnityEngine;

public class GunRotateController : MonoBehaviour
{
    
    public float RotationSpeed { get; set; }

    [SerializeField, ReadOnly]
    private bool _isRotating = true;
    
    [SerializeField, ReadOnly]
    private bool _isLeftRotated = true;
    
    private float _currentAngle = 0;

    public void ChangeRotation()
    {
        _isLeftRotated = !_isLeftRotated;
    }

    public void StopRotating()
    {
        _isRotating = false;
    }

    public void StartRotating()
    {
        _isRotating = true;
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        transform.rotation = Quaternion.AngleAxis(_currentAngle, Vector3.forward);
    }

    // Update is called once per frame
    private void Update()
    {
        if (_isRotating == false) return;
        
        _currentAngle += (_isLeftRotated ? 1 : -1) * RotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(_currentAngle, Vector3.forward);
    }
}
