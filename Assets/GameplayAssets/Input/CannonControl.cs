using System;
using Bootstrap.GameStates;
using TMPro;
using UnityEngine;

namespace GameplayAssets.Input
{
    public class CannonControl : MonoBehaviour
    {
        [SerializeField] private float _sensitivityX = 0.9f;
        [SerializeField] private float _sensitivityY = 0.7f;
        
        private float rotationX;
        private float rotationY;
        
        private IInputService _inputService;  // Сама зависимость
        
        private void Awake() // Тут мы получим зависимость
        {
            _inputService = BootstrapState.RegistrationServices();
        }

        private void Update()
        {
            Rotation();
        }
        
        private void Rotation()
        {
            Vector2 direction = _inputService.AxisGet();
            //print("" + direction);

            float axisX = direction.x * _sensitivityX;
            float axisY = direction.y * _sensitivityY;
 

            rotationX = Mathf.Clamp(rotationX + axisX, -50, 50);
            rotationY = Mathf.Clamp(rotationY - axisY, -30, 10);

            transform.localEulerAngles = new Vector3(rotationY, rotationX, 0);
        }
        
        private void OnEnable()
        {
            _inputService.Input.Enable();
        }

        private void OnDisable()
        {
            _inputService.Input.Disable();
        }
    }
}