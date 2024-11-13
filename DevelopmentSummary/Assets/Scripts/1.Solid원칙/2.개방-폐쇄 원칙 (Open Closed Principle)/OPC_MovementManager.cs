using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
개방 폐쇄 원칙


*/

namespace Solid.Open_Closed_Principle
{
    public class OPC_MovementManager : MonoBehaviour
    {
        [SerializeField]
        GameObject movementObject;

        Movement movement;


        #region 버튼 이벤트용 프로퍼티 (이 코드는 개방 폐쇄 법칙에 위배됨)
        public void ChangeVerticalState()
        {
            movement = MovementFactory.CreateMovement(MovementType.VerticalMovement);
        }
        public void ChangeHorizontalState()
        {
            movement = MovementFactory.CreateMovement(MovementType.HorizontalMovement);
        }
        public void ChangeCircularState()
        {
            movement = MovementFactory.CreateMovement(MovementType.CircularMovement);
        }
        public void ChangeSquareState()
        {
            movement = MovementFactory.CreateMovement(MovementType.SquareMovement);
        }
        #endregion


        private void Awake()
        {
            movement = new HorizontalMovement();
        }
        public void ChangeState(MovementType type)
        {
            movement = MovementFactory.CreateMovement(type);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            movement.Move(movementObject);
        }
    }
    public enum MovementType
    {
        VerticalMovement,
        HorizontalMovement,
        CircularMovement,
        SquareMovement
    }


    public interface Movement
    {
        public void Move(GameObject go);
    }
    public class VerticalMovement : Movement
    {
        public void Move(GameObject go)
        {
            go.transform.position += Vector3.up;
            if (go.transform.position.y > 10f)
                go.transform.position = new Vector3(0, -10, 0);
        }
    }
    public class HorizontalMovement : Movement
    {
        public void Move(GameObject go)
        {
            go.transform.position += Vector3.right;
            if (go.transform.position.x > 10f)
                go.transform.position = new Vector3(-10, 0, 0);
        }
    }
    public class CircularMovement : Movement
    {
        float angle = 0;
        public void Move(GameObject go)
        {
            float y = Mathf.Sin(angle) * 4;
            float x = Mathf.Cos(angle) * 4;

            go.transform.position = new Vector3(x, y);

            angle += 0.1f;
        }
    }
    public class SquareMovement : Movement
    {
        public Vector3 leftTop = new Vector3(-2, 2, 0);
        public Vector3 rightTop = new Vector3(2, 2, 0);
        public Vector3 rightDown = new Vector3(2, -2, 0);
        public Vector3 leftDown = new Vector3(-2, -2, 0);
        public int p = 0;
        public void Move(GameObject go)
        {
            switch (p)
            {
                case 0:
                    go.transform.position = Vector3.MoveTowards(go.transform.position, rightTop, 0.1f);
                    if ((go.transform.position - rightTop).magnitude < 0.1f)
                        p = 1;
                    break;
                case 1:
                    go.transform.position = Vector3.MoveTowards(go.transform.position, rightDown, 0.1f);
                    if ((go.transform.position - rightDown).magnitude < 0.1f)
                        p = 2;
                    break;
                case 2:
                    go.transform.position = Vector3.MoveTowards(go.transform.position, leftDown, 0.1f);
                    if ((go.transform.position - leftDown).magnitude < 0.1f)
                        p = 3;
                    break;
                case 3:
                    go.transform.position = Vector3.MoveTowards(go.transform.position, leftTop, 0.1f);
                    if ((go.transform.position - leftTop).magnitude < 0.1f)
                        p = 0;
                    break;
            }
        }
    }

    public class MovementFactory
    {
        public static Movement CreateMovement(MovementType type)
        {
            switch (type)
            {
                case MovementType.VerticalMovement:
                    return new VerticalMovement();
                case MovementType.HorizontalMovement:
                    return new HorizontalMovement();
                case MovementType.CircularMovement:
                    return new CircularMovement();
                case MovementType.SquareMovement:
                    return new SquareMovement();
                default:
                    throw new ArgumentException("Unsupported movement type");
            }
        }
    }
}
