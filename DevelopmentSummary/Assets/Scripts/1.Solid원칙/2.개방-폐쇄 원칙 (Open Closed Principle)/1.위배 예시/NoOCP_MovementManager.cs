using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
개방 폐쇄 원칙 위배

해당 구조는 NoOPC_MovementManager에 다른 Movement를 추가하려면 
새로운 Movement를 위한 함수를 추가해야함

Movement를 추가할 수 록 코드는 길어지고 결국 통제불능의 상황에 빠지게 됨
*/
namespace Solid.Open_Closed_Principle
{
    public class NoOCP_MovementManager : MonoBehaviour
    {
        [SerializeField]
        GameObject movementObject;

        private MovementType _movementType;

        [SerializeField] private Button VerticalButton;
        [SerializeField] private Button HorizontalButton;
        [SerializeField] private Button CircularButton;
        [SerializeField] private Button SquareButton;
        
        NoOPC_VerticalMovement _verticalMovement;
        NoOCP_HorizontalMovement _horizontalMovement;
        NoOCP_CircularMovement _circularMovement;
        NoOPC_SquareMovement _squareMovement;


        private void Awake()
        {
            VerticalButton.onClick.AddListener(() => { _movementType = MovementType.VerticalMovement; });
            HorizontalButton.onClick.AddListener(() => { _movementType = MovementType.HorizontalMovement; });
            CircularButton.onClick.AddListener(() => { _movementType = MovementType.CircularMovement; });
            SquareButton.onClick.AddListener(() => { _movementType = MovementType.SquareMovement; });
        }
        

        // Update is called once per frame
        void FixedUpdate()
        {
            switch (_movementType)
            {
                case MovementType.VerticalMovement:
                    VerticalMovement();
                    break;
                case MovementType.HorizontalMovement:
                    HorizontalMovement();
                    break;
                case MovementType.CircularMovement:
                    CircularMovement();
                    break;
                case MovementType.SquareMovement:
                    SquareMovement();
                    break;
            }
        }

        private void VerticalMovement()
        {
            if (_verticalMovement == null)
                _verticalMovement = new NoOPC_VerticalMovement();
            
            movementObject.transform.position += Vector3.up;
            if (movementObject.transform.position.y > 10f)
                movementObject.transform.position = _verticalMovement.StartPos;
        }
        private void HorizontalMovement()
        {
            if(_horizontalMovement == null)
                _horizontalMovement = new NoOCP_HorizontalMovement();
            
            movementObject.transform.position += Vector3.right;
            if (movementObject.transform.position.x > 10f)
                movementObject.transform.position = _horizontalMovement.StartPos;
        }
        private void CircularMovement()
        {
            if (_circularMovement == null)
                _circularMovement = new NoOCP_CircularMovement();
            
            float y = Mathf.Sin(_circularMovement.Angle) * 4;
            float x = Mathf.Cos(_circularMovement.Angle) * 4;
            movementObject.transform.position = new Vector3(x, y);
            _circularMovement.Angle += 0.1f;
        }
        private void SquareMovement()
        {
            if (_squareMovement == null)
                _squareMovement = new NoOPC_SquareMovement();
            
            switch (_squareMovement.p)
            {
                case 0:
                    movementObject.transform.position = Vector3.MoveTowards(movementObject.transform.position, _squareMovement.rightTop, 0.1f);
                    if ((movementObject.transform.position - _squareMovement.rightTop).magnitude < 0.1f)
                        _squareMovement.p = 1;
                    break;
                case 1:
                    movementObject.transform.position = Vector3.MoveTowards(movementObject.transform.position, _squareMovement.rightDown, 0.1f);
                    if ((movementObject.transform.position - _squareMovement.rightDown).magnitude < 0.1f)
                        _squareMovement.p = 2;
                    break;
                case 2:
                    movementObject.transform.position = Vector3.MoveTowards(movementObject.transform.position, _squareMovement.leftDown, 0.1f);
                    if ((movementObject.transform.position - _squareMovement.leftDown).magnitude < 0.1f)
                        _squareMovement.p = 3;
                    break;
                case 3:
                    movementObject.transform.position = Vector3.MoveTowards(movementObject.transform.position, _squareMovement.leftTop, 0.1f);
                    if ((movementObject.transform.position - _squareMovement.leftTop).magnitude < 0.1f)
                        _squareMovement.p = 0;
                    break;
            }
        }
    }
}
