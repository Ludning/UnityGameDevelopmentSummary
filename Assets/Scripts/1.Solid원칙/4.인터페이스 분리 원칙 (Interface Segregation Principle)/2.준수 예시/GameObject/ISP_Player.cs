using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solid.Interface_Segregation_Principle
{
    public class ISP_Player : ISP_Unit, ISP_IAttackable
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

        public override void OnMove(Vector2 dir)
        {
            transform.position += new Vector3(dir.x, dir.y, 0) * (Time.deltaTime * 5);
        }

        public void OnAttack()
        {
            Debug.Log("Attack");
            Target?.OnDamage(this, Damage);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<ISP_IDamageable>() == null) 
                return;
            Target = other.GetComponent<ISP_IDamageable>();
            Debug.Log("Find Target");
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<ISP_IDamageable>() == null) 
                return;
            Target = null;
            Debug.Log("Lost Target");
        }
    }
}