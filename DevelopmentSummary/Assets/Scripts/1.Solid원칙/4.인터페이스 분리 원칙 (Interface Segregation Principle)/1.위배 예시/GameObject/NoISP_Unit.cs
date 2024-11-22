using TMPro;
using UnityEngine;

namespace Solid.Interface_Segregation_Principle
{
    public class NoISP_Unit : NoISP_Object
    {
        private bool _isInvincibility;
        private int _hp;
        private int _maxHp;
        private int _damage;
        
        public bool IsInvincibility
        {
            get => _isInvincibility;
            protected set => _isInvincibility = value;
        }
        public int Hp
        {
            get => _hp;
            protected set => _hp = value;
        }
        public int MaxHp
        {
            get => _maxHp;
            protected set => _maxHp = value;
        }
        public int Damage
        {
            get => _damage;
            protected set => _damage = value;
        }
        
        protected override void OnAttack()
        {
            Debug.Log("Attack");
            Target?.OnDamage(this, Damage);
        }
        protected override void InitUI()
        {
            ObjectInfoText.text = $"{gameObject.name}\nHP : {MaxHp} / {Hp}\nDamage : {Damage}";
        }
        
        public override void OnDamage(NoISP_Unit sender, int value)
        {
            if (IsInvincibility == true)
                return;
            
            Hp -= value;
            InitUI();

            if (Hp <= 0)
            {
                sender.Target = null;
                Destroy(gameObject);
            }
        }
        
        public override void OnMove(Vector2 dir)
        {
            transform.position += new Vector3(dir.x, dir.y, 0) * (Time.deltaTime * 5);
        }
    }
}