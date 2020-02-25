// GENERATED AUTOMATICALLY FROM 'Assets/capsuleInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CapsuleInput : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @CapsuleInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""capsuleInput"",
    ""maps"": [
        {
            ""name"": ""capsule"",
            ""id"": ""98a116ad-dd0b-4208-8239-f6eabd28c4cb"",
            ""actions"": [
                {
                    ""name"": ""move"",
                    ""type"": ""Value"",
                    ""id"": ""f3423926-0fd4-43e0-9a32-dfb2e497a98c"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""moveUp"",
                    ""type"": ""Button"",
                    ""id"": ""61f7fb44-639a-42a2-8f14-88b218d5ac6d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""moveDown"",
                    ""type"": ""Button"",
                    ""id"": ""de95979f-c037-4090-9bcb-6605be5f96e3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0edfbb66-0002-475e-b58a-613ccc926492"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be27cb6c-3f92-4659-81b8-f8d2975090c6"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bde7aabc-0785-4bc4-8c05-750682c9a5bc"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // capsule
        m_capsule = asset.FindActionMap("capsule", throwIfNotFound: true);
        m_capsule_move = m_capsule.FindAction("move", throwIfNotFound: true);
        m_capsule_moveUp = m_capsule.FindAction("moveUp", throwIfNotFound: true);
        m_capsule_moveDown = m_capsule.FindAction("moveDown", throwIfNotFound: true);
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

    // capsule
    private readonly InputActionMap m_capsule;
    private ICapsuleActions m_CapsuleActionsCallbackInterface;
    private readonly InputAction m_capsule_move;
    private readonly InputAction m_capsule_moveUp;
    private readonly InputAction m_capsule_moveDown;
    public struct CapsuleActions
    {
        private @CapsuleInput m_Wrapper;
        public CapsuleActions(@CapsuleInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @move => m_Wrapper.m_capsule_move;
        public InputAction @moveUp => m_Wrapper.m_capsule_moveUp;
        public InputAction @moveDown => m_Wrapper.m_capsule_moveDown;
        public InputActionMap Get() { return m_Wrapper.m_capsule; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CapsuleActions set) { return set.Get(); }
        public void SetCallbacks(ICapsuleActions instance)
        {
            if (m_Wrapper.m_CapsuleActionsCallbackInterface != null)
            {
                @move.started -= m_Wrapper.m_CapsuleActionsCallbackInterface.OnMove;
                @move.performed -= m_Wrapper.m_CapsuleActionsCallbackInterface.OnMove;
                @move.canceled -= m_Wrapper.m_CapsuleActionsCallbackInterface.OnMove;
                @moveUp.started -= m_Wrapper.m_CapsuleActionsCallbackInterface.OnMoveUp;
                @moveUp.performed -= m_Wrapper.m_CapsuleActionsCallbackInterface.OnMoveUp;
                @moveUp.canceled -= m_Wrapper.m_CapsuleActionsCallbackInterface.OnMoveUp;
                @moveDown.started -= m_Wrapper.m_CapsuleActionsCallbackInterface.OnMoveDown;
                @moveDown.performed -= m_Wrapper.m_CapsuleActionsCallbackInterface.OnMoveDown;
                @moveDown.canceled -= m_Wrapper.m_CapsuleActionsCallbackInterface.OnMoveDown;
            }
            m_Wrapper.m_CapsuleActionsCallbackInterface = instance;
            if (instance != null)
            {
                @move.started += instance.OnMove;
                @move.performed += instance.OnMove;
                @move.canceled += instance.OnMove;
                @moveUp.started += instance.OnMoveUp;
                @moveUp.performed += instance.OnMoveUp;
                @moveUp.canceled += instance.OnMoveUp;
                @moveDown.started += instance.OnMoveDown;
                @moveDown.performed += instance.OnMoveDown;
                @moveDown.canceled += instance.OnMoveDown;
            }
        }
    }
    public CapsuleActions @capsule => new CapsuleActions(this);
    public interface ICapsuleActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnMoveUp(InputAction.CallbackContext context);
        void OnMoveDown(InputAction.CallbackContext context);
    }
}
