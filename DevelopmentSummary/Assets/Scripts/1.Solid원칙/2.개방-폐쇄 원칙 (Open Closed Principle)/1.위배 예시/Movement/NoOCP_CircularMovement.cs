using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solid.Open_Closed_Principle
{
    public class NoOCP_CircularMovement
    {
        float _radius = 4f;
        public float Radius
        {
            get
            {
                return _radius; 
                
            }
            set
            {
                _radius = value; 
                
            }
        }
        float _angle = 0;
        public float Angle
        {
            get
            {
                return _angle;
            }
            set
            {
                _angle = value;
            } 
            
        }
    }
}