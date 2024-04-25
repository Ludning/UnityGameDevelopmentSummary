using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SRP_Statue), typeof(SRP_Movement), typeof(SRP_PlayerInput))]
public class SRP_Player : MonoBehaviour
{
    /*
    단일 책임 원칙

    모든 클래스는 하나의 책임만 가지며
    클래스는 그 책임을 완전히 캡슐화해야함
    */

    Dictionary<Type, List<SRP_PlayerInput>> m_;

    SRP_Statue statue;
    SRP_Movement movement;
    SRP_PlayerInput input;

    private void Awake()
    {
        statue = GetComponent<SRP_Statue>();
        movement = GetComponent<SRP_Movement>();
        input = GetComponent<SRP_PlayerInput>();
    }
}