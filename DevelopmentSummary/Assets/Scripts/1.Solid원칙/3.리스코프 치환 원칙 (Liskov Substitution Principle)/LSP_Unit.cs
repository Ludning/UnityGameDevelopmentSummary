using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Solid.Liskov_Substitution_Principle
{
    public class LSP_Unit : MonoBehaviour
    {
        protected string unitName;
        protected int hp;
        protected int damage;
        public int Damage => damage;

        public TextMeshProUGUI hpText;

        private void Awake()
        {
            Init();
        }
        public virtual void Init()
        {
        }
        public virtual void OnDamage(int value)
        {
            hp -= value;
        }
        public virtual string GetHp()
        {
            return "";
        }
    }
}