// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputAction/GameInputAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Assets.Scripts.InputActions
{
    public class @GameInputAction : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @GameInputAction()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputAction"",
    ""maps"": [
        {
            ""name"": ""Character"",
            ""id"": ""416746fc-e7da-4226-9e65-2e9d73c2cf53"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1e88be55-c656-4898-8dcf-ab6332049435"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""f226a345-7b2c-4ed8-baa4-3183d3d4ad76"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cdb587d7-9e62-432c-9a45-dae950f2f265"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""b11fd5a3-bed0-4182-8608-3b8f649399e7"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c50f26fc-6508-4bec-8bc8-a4b0b42e8afa"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7fe830de-74fa-4cd6-9b31-56b56566b833"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8317b0ef-4ee3-457d-b48c-eb0a064783f7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""87c45f5c-1f63-45ff-aeee-d62db74cc657"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""MouseMove"",
            ""id"": ""9706ee5d-762f-441d-9006-eac627a893f7"",
            ""actions"": [
                {
                    ""name"": ""Up/Down"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6027cff4-515c-4df3-b916-66eff0570ccd"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left/Right"",
                    ""type"": ""PassThrough"",
                    ""id"": ""66fe8a56-bff2-4949-9307-9066b2533ccf"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""094dba63-d86f-487a-babc-040a5225a8dd"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up/Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c7af73e-242e-46cf-9c64-a7d927195343"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left/Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Character
            m_Character = asset.FindActionMap("Character", throwIfNotFound: true);
            m_Character_Move = m_Character.FindAction("Move", throwIfNotFound: true);
            m_Character_Jump = m_Character.FindAction("Jump", throwIfNotFound: true);
            // MouseMove
            m_MouseMove = asset.FindActionMap("MouseMove", throwIfNotFound: true);
            m_MouseMove_UpDown = m_MouseMove.FindAction("Up/Down", throwIfNotFound: true);
            m_MouseMove_LeftRight = m_MouseMove.FindAction("Left/Right", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        IEnumerator<UnityEngine.InputSystem.InputAction> IEnumerable<UnityEngine.InputSystem.InputAction>.GetEnumerator()
        {
            return ((IEnumerable<UnityEngine.InputSystem.InputAction>)m_Character).GetEnumerator();
        }

        // Character
        private readonly InputActionMap m_Character;
        private ICharacterActions m_CharacterActionsCallbackInterface;
        private readonly InputAction m_Character_Move;
        private readonly InputAction m_Character_Jump;
        public struct CharacterActions
        {
            private @GameInputAction m_Wrapper;
            public CharacterActions(@GameInputAction wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Character_Move;
            public InputAction @Jump => m_Wrapper.m_Character_Jump;
            public InputActionMap Get() { return m_Wrapper.m_Character; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CharacterActions set) { return set.Get(); }
            public void SetCallbacks(ICharacterActions instance)
            {
                if (m_Wrapper.m_CharacterActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMove;
                    @Jump.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                }
                m_Wrapper.m_CharacterActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                }
            }
        }
        public CharacterActions @Character => new CharacterActions(this);

        // MouseMove
        private readonly InputActionMap m_MouseMove;
        private IMouseMoveActions m_MouseMoveActionsCallbackInterface;
        private readonly InputAction m_MouseMove_UpDown;
        private readonly InputAction m_MouseMove_LeftRight;
        public struct MouseMoveActions
        {
            private @GameInputAction m_Wrapper;
            public MouseMoveActions(@GameInputAction wrapper) { m_Wrapper = wrapper; }
            public InputAction @UpDown => m_Wrapper.m_MouseMove_UpDown;
            public InputAction @LeftRight => m_Wrapper.m_MouseMove_LeftRight;
            public InputActionMap Get() { return m_Wrapper.m_MouseMove; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MouseMoveActions set) { return set.Get(); }
            public void SetCallbacks(IMouseMoveActions instance)
            {
                if (m_Wrapper.m_MouseMoveActionsCallbackInterface != null)
                {
                    @UpDown.started -= m_Wrapper.m_MouseMoveActionsCallbackInterface.OnUpDown;
                    @UpDown.performed -= m_Wrapper.m_MouseMoveActionsCallbackInterface.OnUpDown;
                    @UpDown.canceled -= m_Wrapper.m_MouseMoveActionsCallbackInterface.OnUpDown;
                    @LeftRight.started -= m_Wrapper.m_MouseMoveActionsCallbackInterface.OnLeftRight;
                    @LeftRight.performed -= m_Wrapper.m_MouseMoveActionsCallbackInterface.OnLeftRight;
                    @LeftRight.canceled -= m_Wrapper.m_MouseMoveActionsCallbackInterface.OnLeftRight;
                }
                m_Wrapper.m_MouseMoveActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @UpDown.started += instance.OnUpDown;
                    @UpDown.performed += instance.OnUpDown;
                    @UpDown.canceled += instance.OnUpDown;
                    @LeftRight.started += instance.OnLeftRight;
                    @LeftRight.performed += instance.OnLeftRight;
                    @LeftRight.canceled += instance.OnLeftRight;
                }
            }
        }
        public MouseMoveActions @MouseMove => new MouseMoveActions(this);
        public interface ICharacterActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
        }
        public interface IMouseMoveActions
        {
            void OnUpDown(InputAction.CallbackContext context);
            void OnLeftRight(InputAction.CallbackContext context);
        }
    }
}