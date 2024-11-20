using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

/*
개방 폐쇄 원칙 준수

해당 구조는 새로운 움직임이 필요할 때마다 OCP_IMovement를 상속하는 새 클래스를 정의.
인터페이스와 추상화를 활용하면 나중에 확장하기 까다로운 switch 또는 if 문을 로직에 넣지 않아도 됨.
익숙해지면 장기적으로 새로운 코드를 더 간편하게 추가할 수 있게 됨.
*/

namespace Solid.Open_Closed_Principle
{
    public class OCP_MovementManager : MonoBehaviour
    {
        [SerializeField] private GameObject _movementObject;

        private OCP_IMovement _ocpMovement;

        private void Awake()
        {
            _ocpMovement = new OCP_HorizontalMovement();
        }
        public void ChangeState(MovementType type)
        {
            _ocpMovement = MovementFactory.CreateMovement(type);
        }
        void FixedUpdate()
        {
            _ocpMovement.Move(_movementObject);
        }
    }
}
