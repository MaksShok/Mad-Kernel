using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameplayAssets.Input
{
    public class MobileInputService : IInputService
    {
        private InputController _input;
        public InputController Input { get { return _input; } }

        public MobileInputService()
        {
            _input = new InputController();
            
            _input.Enable();

            //_input.UI.Shoot.performed += Shoot;

            Cursor.visible = false;
        }

        public Vector2 AxisGet()
        {
            return _input.UI.Rotation.ReadValue<Vector2>();
        }
    }
}