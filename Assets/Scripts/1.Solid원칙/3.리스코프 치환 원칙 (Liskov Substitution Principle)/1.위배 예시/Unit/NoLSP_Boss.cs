using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Solid.Liskov_Substitution_Principle
{
    public class NoLSP_Boss : NoLSP_Monster
    {
        protected override void InitData()
        {
            UnitName = "Boss";
            Level = 10;
            Hp = 1000;
            Damage = 10;
        }
        
        public override void OnDamage(int value)
        {
            Hp -= value;
            if (hpText != null)
                hpText.SetText($"{UnitName} HP : {Hp}");
        }
    }
}
