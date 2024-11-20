using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solid.Open_Closed_Principle
{
    public class OCP_CircularMovement : OCP_IMovement
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
}