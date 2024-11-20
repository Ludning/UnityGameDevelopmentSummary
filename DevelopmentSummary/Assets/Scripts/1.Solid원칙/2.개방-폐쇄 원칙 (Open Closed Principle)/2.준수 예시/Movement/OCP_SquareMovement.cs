using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solid.Open_Closed_Principle
{
    public class OCP_SquareMovement : OCP_IMovement
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
}