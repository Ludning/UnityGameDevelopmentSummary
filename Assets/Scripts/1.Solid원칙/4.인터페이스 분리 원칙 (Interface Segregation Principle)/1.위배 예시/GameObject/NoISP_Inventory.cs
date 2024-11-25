using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solid.Interface_Segregation_Principle
{
    public class NoISP_Inventory : MonoBehaviour
    {
        private NoISP_Item _targetItem;
        private NoISP_Item _ownedItem;
        
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
            Debug.Log("Add Item");
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
            if (other.GetComponent<NoISP_Item>() == null) 
                return;
            _targetItem = other.GetComponent<NoISP_Item>();
            Debug.Log("Find Item");
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<NoISP_Item>() == null) 
                return;
            _targetItem = null;
            Debug.Log("Lost Item");
        }
    }
}