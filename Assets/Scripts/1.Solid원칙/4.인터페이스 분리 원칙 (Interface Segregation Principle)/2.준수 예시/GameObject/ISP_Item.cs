using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solid.Interface_Segregation_Principle
{
    public class ISP_Item : ISP_Prop, ISP_IPickable
    {
        /*public void OnPickUp(ISP_Inventory owner)
        {
            transform.SetParent(owner.transform);
        }

        public void OnPickDown(ISP_Inventory owner)
        {
            transform.SetParent(null);
        }*/

        public void OnPickUp(Func<Transform> func)
        {
            transform.SetParent(func());
        }

        public void OnPickDown(Func<Transform> func)
        {
            transform.SetParent(null);
        }
    }
}