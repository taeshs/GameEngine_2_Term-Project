using UnityEngine;
using UnityEngine.InputSystem;
using Scripts.Inventory;

namespace Assets.Scripts.InputActions
{

    public class CharacterMoveController : MonoBehaviour, GameInputAction.ICharacterActions
    {
        private CharacterController _characterController;
        private GameInputAction _inputAction;
        private Vector2 _moveActionValue;
        private float _fallingSpeed = 0f;
        private bool _isGrounded; //참이면 땅바닥에 붙음
        private bool _isJumped;
        private float _timer;

        private const float gravity = -9.81f;



        [SerializeField] private float characterMoveSpeed = 10f;
        [SerializeField] private Transform groundCheckPosition;
        [SerializeField] private float groundCheckOffset = 0.1f;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float jumpPower = 10f;
        [SerializeField] private float jumpTime = 1f;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        void Start()
        {

        }

        private void OnEnable()
        {

            if (_inputAction == null)
                _inputAction = new GameInputAction();

            _inputAction.Character.SetCallbacks(instance: this);
            _inputAction.Character.Enable();

        }

        void Update()
        {
            _isGrounded = Physics.CheckSphere(groundCheckPosition.position, groundCheckOffset, groundLayer);

            if (_isGrounded)
            {
                _fallingSpeed = 0f;
            }

            var verticalVector = transform.forward * (_moveActionValue.y * Time.deltaTime * characterMoveSpeed);// 앞방향
            var horizontalVector = transform.right * (_moveActionValue.x * Time.deltaTime * characterMoveSpeed);
            _characterController.Move(motion: verticalVector + horizontalVector);

            _fallingSpeed = Time.deltaTime * gravity;
            _characterController.Move(motion: new Vector3(x: 0, y: _fallingSpeed, z: 0));

            if (_isJumped)
            {
                if (_timer < jumpTime)
                {
                    _timer += Time.deltaTime;
                }
                else
                {
                    _timer = 0f;
                    _isJumped = false;
                }
                var power = jumpPower * Time.deltaTime;
                _characterController.Move(motion: new Vector3(x: 0, y: power, z: 0));

            }
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            _moveActionValue = context.ReadValue<Vector2>();
        }


        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
                _isJumped = true;
            else
                _isJumped = false;
        }
        public void OnUseItem1(InputAction.CallbackContext context)
        {
            print("use stone");
            InventoryManager.Instance.UseItem("stone");
        }
        public void OnUseItem2(InputAction.CallbackContext context)
        {
            print("use crystal");
            InventoryManager.Instance.UseItem("crystal");
        }
        public void OnUseItem3(InputAction.CallbackContext context)
        {
            print("use statue");
            InventoryManager.Instance.UseItem("statue");
        }
        public void OnUseItem4(InputAction.CallbackContext context)
        {
            InventoryManager.Instance.AddItem("crystal");
            InventoryManager.Instance.AddItem("stone");
            InventoryManager.Instance.AddItem("statue");
        }
        /*
        public void OnSprint(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        public void OnChrouch(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }
        */
    }

}