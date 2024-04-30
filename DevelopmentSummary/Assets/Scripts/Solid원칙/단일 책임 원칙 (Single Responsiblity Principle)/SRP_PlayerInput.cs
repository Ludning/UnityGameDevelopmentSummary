using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace Single_Responsiblity_Principle
{
    public class SRP_PlayerInput : MonoBehaviour
    {
        float vertical;
        float horizontal;
        SRP_Player player;
        private void Awake()
        {
            player = GetComponent<SRP_Player>();
        }
        void Update()
        {
            vertical = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Horizontal");

            player.GetPlayerComponent<SRP_Movement>().SetAxis(new Vector3(horizontal, 0, vertical));
        }

    }
}
