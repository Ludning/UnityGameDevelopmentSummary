using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SRP_Statue), typeof(SRP_Movement), typeof(SRP_PlayerInput))]
public class SRP_Player : MonoBehaviour
{
    /*
    ���� å�� ��Ģ

    ��� Ŭ������ �ϳ��� å�Ӹ� ������
    Ŭ������ �� å���� ������ ĸ��ȭ�ؾ���
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