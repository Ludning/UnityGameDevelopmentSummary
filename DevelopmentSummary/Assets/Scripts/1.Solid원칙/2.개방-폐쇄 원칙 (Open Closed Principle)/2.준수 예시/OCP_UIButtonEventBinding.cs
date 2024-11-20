using System;
using System.Collections;
using System.Collections.Generic;
using Solid.Open_Closed_Principle;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Solid.Open_Closed_Principle
{
    public class OCP_UIButtonEventBinding : MonoBehaviour
    {
        [SerializeField] private Button VerticalButton;
        [SerializeField] private Button HorizontalButton;
        [SerializeField] private Button CircularButton;
        [SerializeField] private Button SquareButton;

        [FormerlySerializedAs("OpcMovementManager")] [SerializeField] OCP_MovementManager ocpMovementManager;

        private void Awake()
        {
            VerticalButton.onClick.AddListener(() => ocpMovementManager.ChangeState(MovementType.VerticalMovement));
            HorizontalButton.onClick.AddListener(() => ocpMovementManager.ChangeState(MovementType.HorizontalMovement));
            CircularButton.onClick.AddListener(() => ocpMovementManager.ChangeState(MovementType.CircularMovement));
            SquareButton.onClick.AddListener(() => ocpMovementManager.ChangeState(MovementType.SquareMovement));
        }
    }
}
