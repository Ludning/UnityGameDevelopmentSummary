using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solid.Open_Closed_Principle
{
    public static class MovementFactory
    {
        public static OCP_IMovement CreateMovement(MovementType type)
        {
            switch (type)
            {
                case MovementType.VerticalMovement:
                    return new OCP_VerticalMovement();
                case MovementType.HorizontalMovement:
                    return new OCP_HorizontalMovement();
                case MovementType.CircularMovement:
                    return new OCP_CircularMovement();
                case MovementType.SquareMovement:
                    return new OCP_SquareMovement();
                default:
                    throw new ArgumentException("Unsupported movement type");
            }
        }
    }
}