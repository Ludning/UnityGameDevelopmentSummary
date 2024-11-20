using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solid.Open_Closed_Principle
{
    public class OCP_VerticalMovement : OCP_IMovement
    {
        public void Move(GameObject go)
        {
            go.transform.position += Vector3.up;
            if (go.transform.position.y > 10f)
                go.transform.position = new Vector3(0, -10, 0);
        }
    }
}