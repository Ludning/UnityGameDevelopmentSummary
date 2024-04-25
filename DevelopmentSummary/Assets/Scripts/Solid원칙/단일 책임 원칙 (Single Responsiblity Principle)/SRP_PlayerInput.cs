using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SRP_PlayerInput : MonoBehaviour
{
    float vertical;
    float horizontal;

    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");


    }

}
