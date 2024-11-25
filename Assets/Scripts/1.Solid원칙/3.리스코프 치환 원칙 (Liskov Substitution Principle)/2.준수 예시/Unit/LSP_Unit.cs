using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Solid.Liskov_Substitution_Principle
{
    public abstract class LSP_Unit : MonoBehaviour
    {
        private string _unitName;
        private int _level;
        private int _hp;
        private int _damage;
        
        public string UnitName
        {
            get => _unitName;
            protected set => _unitName = value;
        }
        public int Level
        {
            get => _level;
            protected set => _level = value;
        }
        public int Hp
        {
            get => _hp;
            protected set => _hp = value;
        }
        public int Damage
        {
            get => _damage;
            protected set => _damage = value;
        }

        public TextMeshProUGUI hpText;

        private void Awake()
        {
            InitData();
            InitUI();
        }

        protected abstract void InitData();

        protected abstract void InitUI();

        public abstract void OnDamage(int value);
        
    }
}