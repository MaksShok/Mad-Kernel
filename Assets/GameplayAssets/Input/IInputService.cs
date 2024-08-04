using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameplayAssets.Input
{
    public interface IInputService
    {
        public InputController Input { get; }
        public Vector2 AxisGet();
    }
}