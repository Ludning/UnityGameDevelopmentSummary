using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComponentType
{
    SRP_Statue,
    SRP_Movement,
    SRP_PlayerInput
}

[RequireComponent(typeof(SRP_Statue), typeof(SRP_Movement), typeof(SRP_PlayerInput))]
[RequireComponent(typeof(SRP_PrintLog))]
public class SRP_Player : MonoBehaviour
{
    /*
    ���� å�� ��Ģ

    ��� Ŭ������ �ϳ��� å�Ӹ� ������
    Ŭ������ �� å���� ������ ĸ��ȭ �ؾ� �Ѵ�.

    ������ ����� ����ϴ� Ŭ������ �����ϴ°��� ������������ ������ �����ϴ�.
    */
    Dictionary<Type, MonoBehaviour> componentDic = new Dictionary<Type, MonoBehaviour>();

    private void Awake()
    {
        componentDic.Add(typeof(SRP_Statue), GetComponent<SRP_Statue>());
        componentDic.Add(typeof(SRP_Movement), GetComponent<SRP_Movement>());
        componentDic.Add(typeof(SRP_PlayerInput), GetComponent<SRP_PlayerInput>());
        componentDic.Add(typeof(SRP_PrintLog), GetComponent<SRP_PrintLog>());
    }
    public T GetPlayerComponent<T>() where T : MonoBehaviour
    {
        return componentDic[typeof(T)] as T;
    }
}