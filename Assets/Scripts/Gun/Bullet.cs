using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Dieble))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    private LayerMask _whatIsTarget;
    
    private float _speed;
    private Dieble _dieble;

    private void Awake()
    {
        _dieble = GetComponent<Dieble>();
    }

    public void Init(float bulletSpeed)
    {
        _speed = bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (((1 << other.gameObject.layer) & _whatIsTarget) != 0)
        {
            _dieble.Die();
        }
    }
}
