using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
°³¹æ Æó¼â ¿øÄ¢



*/
public class OPC_MovementManager : MonoBehaviour
{
    [SerializeField]
    GameObject movementObject;

    Movement movement;

    private void Awake()
    {
        movement = new HorizontalMovement();
    }

    public void ChangeVerticalMovement()
    {
        ChangeState(MovementType.VerticalMovement);
    }
    public void ChangeHorizontalMovement()
    {
        ChangeState(MovementType.HorizontalMovement);
    }
    public void ChangeCircularMovement()
    {
        ChangeState(MovementType.CircularMovement);
    }
    public void ChangeSquareMovement()
    {
        ChangeState(MovementType.SquareMovement);
    }
    public void ChangeState(MovementType type)
    {
        switch (type)
        {
            case MovementType.VerticalMovement:
                movement = new VerticalMovement();
                break;
            case MovementType.HorizontalMovement:
                movement = new HorizontalMovement();
                break;
            case MovementType.CircularMovement:
                movement = new CircularMovement();
                break;
            case MovementType.SquareMovement:
                movement = new SquareMovement();
                break;
            default:
                movement = new VerticalMovement();
                break;
        }
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
        if(go.transform.position.y > 10f )
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

