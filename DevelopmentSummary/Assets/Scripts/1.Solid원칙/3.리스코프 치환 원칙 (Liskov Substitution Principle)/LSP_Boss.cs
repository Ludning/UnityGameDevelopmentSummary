using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solid.Liskov_Substitution_Principle
{
    public class LSP_Boss : LSP_Monster
    {
        public override void Init()
        {
            unitName = "Boss";
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
