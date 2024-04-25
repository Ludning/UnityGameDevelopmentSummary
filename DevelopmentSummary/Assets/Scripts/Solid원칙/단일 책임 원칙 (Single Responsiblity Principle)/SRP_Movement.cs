using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SRP_Movement : MonoBehaviour
{
    private bool _isMoving = false;
    private Vector3 _direction = Vector3.zero;
    private float _speed = 10f;
    private Rigidbody _myRigidbody;

    private void Awake()
    {
        _myRigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        if(direction == Vector3.zero)
        {
            _isMoving = false;
            _direction = direction;
        }
        else
        {
            _isMoving = true;
            _direction = direction;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(_isMoving)
        {
            _myRigidbody.velocity = _direction;
        }
    }
}