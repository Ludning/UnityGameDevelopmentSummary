using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solid.Interface_Segregation_Principle
{
    public class NoISP_Enemy : NoISP_Unit
    {
        protected override void InitData()
        {
            Hp = 100;
            MaxHp = 100;
            Damage = 10;
        }
    }
}