using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solid.Interface_Segregation_Principle
{
    public class ISP_Unit : ISP_Object, ISP_IDamageable, ISP_IMoveable
    {
        public ISP_IDamageable Target { get; set; } = null;

        protected override void InitUI()
        {
            ObjectInfoText.text = $"{gameObject.name}\nHP : {MaxHp} / {Hp}\nDamage : {Damage}";
        }

        public virtual void OnDamage(ISP_Unit sender, int value)
        {
            Hp -= value;
            InitUI();

            if (Hp <= 0)
            {
                sender.Target = null;
                Destroy(gameObject);
            }
        }

        public virtual void OnMove(Vector2 dir)
        {
            
        }
    }
}