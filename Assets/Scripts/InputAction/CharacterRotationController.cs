using System;
using UnityEngine;
using UnityEngine.InputSystem;
using KPU;
using KPU.Manager;

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
             EventManager.On("game_started", OnGameStart);
            EventManager.On("game_ended", OnGameEnd);
            gameObject.SetActive(false); // 게임이 시작되면 감춰진 상태로 놓는다

           
        }

          private void OnGameStart(object obj)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            gameObject.SetActive(true);

            //_throwRoutine = StartCoroutine(ShootRoutine());
        }

          private void OnGameEnd(object obj)
        {
            //StopCoroutine(_throwRoutine);
            gameObject.SetActive(false);
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