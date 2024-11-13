using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solid.Single_Responsiblity_Principle
{
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
        단일 책임 원칙

        모든 클래스는 하나의 책임만 가지며
        클래스는 그 책임을 완전히 캡슐화 해야 한다.

        각자의 기능을 담당하는 클래스로 분할하는것이 유지보수등의 관리에 유리하다.
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
}
