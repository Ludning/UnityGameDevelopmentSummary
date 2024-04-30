using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Liskov_Substitution_Principle
{
    public class LSP_Monster : LSP_Unit
    {
        public override void Init()
        {
            unitName = "Monster";
            hp = 1000;
            damage = 10;
        }
        public override void OnDamage(int value)
        {
            hp -= value;
        }
        public override string GetHp()
        {
            return $"{unitName}HP : {hp}";
        }
    }
}