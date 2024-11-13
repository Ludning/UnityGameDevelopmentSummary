using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Solid.Liskov_Substitution_Principle
{
    public class LSP_Player : LSP_Unit
    {
        public override void Init()
        {
            unitName = "Player";
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