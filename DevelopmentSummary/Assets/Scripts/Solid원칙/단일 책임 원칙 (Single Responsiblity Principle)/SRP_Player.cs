using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SRP_Statue), typeof(SRP_Controller))]
public class SRP_Player : MonoBehaviour
{
    SRP_Statue statue;
    SRP_Controller controller;
    private void Awake()
    {
        statue = GetComponent<SRP_Statue>();
        controller = GetComponent<SRP_Controller>();
    }
}
