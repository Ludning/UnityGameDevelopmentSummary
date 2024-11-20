using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solid.Interface_Segregation_Principle
{
    public class ISP_Inventory : MonoBehaviour
    {
        private ISP_IPickable _targetItem;
        private ISP_IPickable _ownedItem;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
                AddItem();
            if(Input.GetKeyDown(KeyCode.G))
                DropItem();
        }

        public void AddItem()
        {
            if (_targetItem == null) return;
            _targetItem.OnPickUp(this);
            _ownedItem = _targetItem;
        }
        public void DropItem()
        {
            if (_targetItem == null) return;
            _targetItem.OnPickDown(this);
            _ownedItem = null;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<ISP_IPickable>() == null) 
                return;
            _targetItem = other.GetComponent<ISP_IPickable>();
            Debug.Log("Find Item");
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<ISP_IPickable>() == null) 
                return;
            _targetItem = null;
            Debug.Log("Lost Item");
        }
    }
}