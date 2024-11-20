using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Solid.Interface_Segregation_Principle
{
    public class ISP_Object : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _objectInfoText;
        private bool _isInvincibility;
        private int _hp;
        private int _maxHp;
        private int _damage;

        public TextMeshProUGUI ObjectInfoText => _objectInfoText;
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
    }
}