using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.InputActions
{
    public class CharacterRotationController : MonoBehaviour, GameInputAction.IMouseMoveActions
    {
        public float mouseSensitivity = 10f;
        private float _mouseYDelta;
        private float _mouseXDelta;

        private float _xRot;
        private float _yRot;

        private GameInputAction _actionControl;

        public void OnUpDown(InputAction.CallbackContext context)
        {
            _mouseYDelta = context.ReadValue<float>();
        }

        public void OnLeftRight(InputAction.CallbackContext context)
        {
            _mouseXDelta = context.ReadValue<float>();
        }



        void Awake()
        {

        }

        private void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        void OnEnable()
        {
            if (_actionControl == null)
            {
                _actionControl = new GameInputAction();
                _actionControl.MouseMove.SetCallbacks(this);
            }

            _actionControl.MouseMove.Enable();
        }


        private void Update()
        {
            var mouseX = _mouseXDelta * Time.deltaTime * mouseSensitivity;
            var mouseY = _mouseYDelta * Time.deltaTime * mouseSensitivity;

            transform.Rotate(new Vector3(0, mouseX * 2, 0));
        }
    }

}