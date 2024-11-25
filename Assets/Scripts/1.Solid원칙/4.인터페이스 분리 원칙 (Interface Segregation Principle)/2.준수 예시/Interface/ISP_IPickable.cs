using System;
using UnityEngine;

namespace Solid.Interface_Segregation_Principle
{
    public interface ISP_IPickable
    {
        public void OnPickUp(Func<Transform> func);
        public void OnPickDown(Func<Transform> func);
    }
}