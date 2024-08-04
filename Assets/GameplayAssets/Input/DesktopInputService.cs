using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameplayAssets.Input
{
    public class DesktopInputService : IInputService
    {
        private InputController _input;
        public InputController Input { get { return _input; } }
        
        public DesktopInputService()
        {
            _input = new InputController();
            _input.Enable();

            //_input.Shoot.performed += Shoot;

            Cursor.visible = false;
        }
        
        public Vector2 AxisGet()
        {
            return _input.Desktop.Rotation.ReadValue<Vector2>();
        }
    }
}