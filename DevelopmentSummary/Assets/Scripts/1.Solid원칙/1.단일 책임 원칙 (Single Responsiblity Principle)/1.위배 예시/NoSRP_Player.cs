using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solid.Single_Responsiblity_Principle
{
    public class NoSRP_Player : MonoBehaviour
    {
        private int _hp;
        public int HP => _hp;

        private int _mp;
        public int MP => _mp;

        private int _attack;
        public int Attack => _attack;

        private int _defence;
        public int Defence => _defence;
        
        private float _vertical;
        private float _horizontal;
        
        private bool _isMoving = false;
        private Vector3 _direction = Vector3.zero;
        [SerializeField] private float _speed = 10f;
        
        private Rigidbody _myRigidbody;

        private void Awake()
        {
            _myRigidbody = GetComponent<Rigidbody>();
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            _vertical = Input.GetAxis("Vertical");
            _horizontal = Input.GetAxis("Horizontal");

            Vector3 direction = new Vector3(_horizontal, 0, _vertical);
            if (direction == Vector3.zero)
                _isMoving = false;
            else
                _isMoving = true;
            _direction = direction;
        }
        
        void FixedUpdate()
        {
            if (_isMoving)
                _myRigidbody.velocity = _direction * _speed;
        }
    }
}