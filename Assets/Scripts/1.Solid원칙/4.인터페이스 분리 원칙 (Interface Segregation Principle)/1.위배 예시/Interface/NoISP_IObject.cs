using System;
using UnityEngine;

namespace Solid.Interface_Segregation_Principle
{
    public interface NoISP_IObject
    {
        public NoISP_IObject Target { get; set; }
        public void OnDamage(NoISP_Unit sender, int value);
        public void OnMove(Vector2 dir);
        public void OnPickUp(Func<Transform> func);
        public void OnPickDown(Func<Transform> func);
    }
}