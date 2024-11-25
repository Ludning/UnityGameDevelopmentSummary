using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solid.Open_Closed_Principle
{
    public class OCP_HorizontalMovement : OCP_IMovement
    {
        public void Move(GameObject go)
        {
            go.transform.position += Vector3.right;
            if (go.transform.position.x > 10f)
                go.transform.position = new Vector3(-10, 0, 0);
        }
    }
}