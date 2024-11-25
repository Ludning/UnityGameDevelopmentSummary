using System;
using TMPro;
using UnityEngine;

namespace Solid.Interface_Segregation_Principle
{
    public class NoISP_Object : MonoBehaviour, NoISP_IObject
    {
        [SerializeField] private TextMeshProUGUI _objectInfoText;
        public TextMeshProUGUI ObjectInfoText => _objectInfoText;
        
        public virtual NoISP_IObject Target { get; set; }
        
        private void Awake()
        {
            OnAwake();
        }
        private void Update()
        {
            OnUpdate();
        }
        private void FixedUpdate()
        {
            OnFixedUpdate();
        }

        protected virtual void OnAwake()
        {
            InitData();
            InitUI();
        }
        protected virtual void OnUpdate()
        {
        }
        protected virtual void OnFixedUpdate()
        {
        }
        protected virtual void InitData()
        {
        }
        protected virtual void InitUI()
        {
            _objectInfoText.text = gameObject.name;
        }

        public virtual void OnDamage(NoISP_Unit sender, int value)
        {
        }
        public virtual void OnMove(Vector2 dir)
        {
        }
        protected virtual void OnAttack()
        {
        }
        public void OnPickUp(Func<Transform> func)
        {
        }
        public void OnPickDown(Func<Transform> func)
        {
        }
    }
}