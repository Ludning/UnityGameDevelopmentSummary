using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solid.Single_Responsiblity_Principle
{
    public class SRP_PrintLog : MonoBehaviour
    {
        SRP_Player player;
        private void Awake()
        {
            player = GetComponent<SRP_Player>();
        }
        public void PrintLog(MonoBehaviour sender, string context)
        {
            Debug.Log($"{sender} : {context}");
        }
    }
}