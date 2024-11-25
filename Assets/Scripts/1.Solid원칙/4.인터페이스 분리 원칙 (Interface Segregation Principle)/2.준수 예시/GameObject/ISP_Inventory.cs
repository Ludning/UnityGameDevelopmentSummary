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

        private void AddItem()
        {
            if (_targetItem == null) return;
            _targetItem.OnPickUp(GetTransform);
            _ownedItem = _targetItem;
        }
        private void DropItem()
        {
            if (_targetItem == null) return;
            _targetItem.OnPickDown(GetTransform);
            _ownedItem = null;
        }

        private Transform GetTransform()
        {
            return transform;
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