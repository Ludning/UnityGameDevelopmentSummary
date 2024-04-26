using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SRP_Movement : MonoBehaviour
{
    private bool _isMoving = false;
    private Vector3 _direction = Vector3.zero;
    [SerializeField]
    private float _speed = 10f;
    private Rigidbody _myRigidbody;

    SRP_Player player;
    private void Awake()
    {
        player = GetComponent<SRP_Player>();
        _myRigidbody = GetComponent<Rigidbody>();
    }

    public void SetAxis(Vector3 direction)
    {
        if (direction == Vector3.zero)
            _isMoving = false;
        else
            _isMoving = true;
        _direction = direction;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _myRigidbody.velocity = _direction * _speed;
    }
}