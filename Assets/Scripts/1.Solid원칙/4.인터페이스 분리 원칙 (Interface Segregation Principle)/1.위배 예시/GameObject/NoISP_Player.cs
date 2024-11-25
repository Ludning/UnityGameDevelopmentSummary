using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solid.Interface_Segregation_Principle
{
    public class NoISP_Player : NoISP_Unit
    {
        Vector2 _direction = Vector2.zero;
        protected override void InitData()
        {
            Hp = 100;
            MaxHp = 100;
            Damage = 10;
        }

        protected override void OnFixedUpdate()
        {
            OnMove(_direction);
        }

        protected override void OnUpdate()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            _direction = new Vector2(horizontal, vertical);
            
            if(Input.GetKeyDown(KeyCode.Space))
                OnAttack();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<NoISP_IObject>() == null) 
                return;
            Target = other.GetComponent<NoISP_IObject>();
            Debug.Log("Find Target");
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<NoISP_IObject>() == null) 
                return;
            Target = null;
            Debug.Log("Lost Target");
        }
    }
}