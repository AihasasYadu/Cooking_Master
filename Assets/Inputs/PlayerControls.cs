//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Inputs/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""MovementA"",
            ""id"": ""753602a1-fe0b-4c1a-9724-adb1f34164ae"",
            ""actions"": [
                {
                    ""name"": ""Pick"",
                    ""type"": ""Button"",
                    ""id"": ""60335942-3829-4043-8e89-2d3bd0fe7c2b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Drop"",
                    ""type"": ""Button"",
                    ""id"": ""85ca9ccb-5d0a-414f-a71a-46f258bda1d7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""1d566efc-8f04-4bac-9cfb-92efb3c6042e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Serve"",
                    ""type"": ""Button"",
                    ""id"": ""7be3cdd8-e67c-45c4-a670-d1f3b8ec97c5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d070ea7a-9f9b-463d-a0a7-f212c42f3786"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""5b1defee-44ce-4192-9b88-23cb44836189"",
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
                    ""id"": ""cfc6b40a-c6c4-49cc-aeff-0b38c3fbc432"",
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
                    ""id"": ""747be121-6aec-4b38-b84d-427a982d2005"",
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
                    ""id"": ""3c5655e7-2e01-413f-86b0-5872f7958843"",
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
                    ""id"": ""b1c269ca-e6d0-4483-82ae-b8f41039e957"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2459cfde-1a28-43f9-91d3-a0a95c4d66b4"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""383d7310-d369-4874-8d12-8cec92c161d1"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Serve"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MovementB"",
            ""id"": ""c996dc8e-6751-47fe-b106-6809ce4e6d80"",
            ""actions"": [
                {
                    ""name"": ""Pick"",
                    ""type"": ""Button"",
                    ""id"": ""48e34d70-bce6-407c-9df1-036149114daf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Drop"",
                    ""type"": ""Button"",
                    ""id"": ""f82f0b31-a739-46d9-9cf4-1b6fe5a9f21e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""5630acda-ef5e-4d06-a317-ba697a3a8cac"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Serve"",
                    ""type"": ""Button"",
                    ""id"": ""94dc7924-ab07-495c-9357-02b106602d62"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ed0db981-de0a-44cf-8de4-b1a202c24e62"",
                    ""path"": ""<Keyboard>/numpad7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""fbce8bf4-1ff3-4b42-9988-9be5afde716a"",
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
                    ""id"": ""359df967-4aea-408e-b288-98ce52815b03"",
                    ""path"": ""<Keyboard>/numpad8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""06815130-b2bf-4cab-9ecf-7e65402e1d6b"",
                    ""path"": ""<Keyboard>/numpad2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fa729966-8fdb-4456-bacf-772ac7eda016"",
                    ""path"": ""<Keyboard>/numpad4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7036a5a7-8b93-4e73-ad2a-776af696910d"",
                    ""path"": ""<Keyboard>/numpad6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7e782721-40c1-43e4-9ffd-ac5b20452ab4"",
                    ""path"": ""<Keyboard>/numpad0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a16c25f-efb0-4682-bd03-9b2b5cf5a528"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Serve"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MovementA
        m_MovementA = asset.FindActionMap("MovementA", throwIfNotFound: true);
        m_MovementA_Pick = m_MovementA.FindAction("Pick", throwIfNotFound: true);
        m_MovementA_Drop = m_MovementA.FindAction("Drop", throwIfNotFound: true);
        m_MovementA_Move = m_MovementA.FindAction("Move", throwIfNotFound: true);
        m_MovementA_Serve = m_MovementA.FindAction("Serve", throwIfNotFound: true);
        // MovementB
        m_MovementB = asset.FindActionMap("MovementB", throwIfNotFound: true);
        m_MovementB_Pick = m_MovementB.FindAction("Pick", throwIfNotFound: true);
        m_MovementB_Drop = m_MovementB.FindAction("Drop", throwIfNotFound: true);
        m_MovementB_Move = m_MovementB.FindAction("Move", throwIfNotFound: true);
        m_MovementB_Serve = m_MovementB.FindAction("Serve", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // MovementA
    private readonly InputActionMap m_MovementA;
    private IMovementAActions m_MovementAActionsCallbackInterface;
    private readonly InputAction m_MovementA_Pick;
    private readonly InputAction m_MovementA_Drop;
    private readonly InputAction m_MovementA_Move;
    private readonly InputAction m_MovementA_Serve;
    public struct MovementAActions
    {
        private @PlayerControls m_Wrapper;
        public MovementAActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pick => m_Wrapper.m_MovementA_Pick;
        public InputAction @Drop => m_Wrapper.m_MovementA_Drop;
        public InputAction @Move => m_Wrapper.m_MovementA_Move;
        public InputAction @Serve => m_Wrapper.m_MovementA_Serve;
        public InputActionMap Get() { return m_Wrapper.m_MovementA; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementAActions set) { return set.Get(); }
        public void SetCallbacks(IMovementAActions instance)
        {
            if (m_Wrapper.m_MovementAActionsCallbackInterface != null)
            {
                @Pick.started -= m_Wrapper.m_MovementAActionsCallbackInterface.OnPick;
                @Pick.performed -= m_Wrapper.m_MovementAActionsCallbackInterface.OnPick;
                @Pick.canceled -= m_Wrapper.m_MovementAActionsCallbackInterface.OnPick;
                @Drop.started -= m_Wrapper.m_MovementAActionsCallbackInterface.OnDrop;
                @Drop.performed -= m_Wrapper.m_MovementAActionsCallbackInterface.OnDrop;
                @Drop.canceled -= m_Wrapper.m_MovementAActionsCallbackInterface.OnDrop;
                @Move.started -= m_Wrapper.m_MovementAActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MovementAActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MovementAActionsCallbackInterface.OnMove;
                @Serve.started -= m_Wrapper.m_MovementAActionsCallbackInterface.OnServe;
                @Serve.performed -= m_Wrapper.m_MovementAActionsCallbackInterface.OnServe;
                @Serve.canceled -= m_Wrapper.m_MovementAActionsCallbackInterface.OnServe;
            }
            m_Wrapper.m_MovementAActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pick.started += instance.OnPick;
                @Pick.performed += instance.OnPick;
                @Pick.canceled += instance.OnPick;
                @Drop.started += instance.OnDrop;
                @Drop.performed += instance.OnDrop;
                @Drop.canceled += instance.OnDrop;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Serve.started += instance.OnServe;
                @Serve.performed += instance.OnServe;
                @Serve.canceled += instance.OnServe;
            }
        }
    }
    public MovementAActions @MovementA => new MovementAActions(this);

    // MovementB
    private readonly InputActionMap m_MovementB;
    private IMovementBActions m_MovementBActionsCallbackInterface;
    private readonly InputAction m_MovementB_Pick;
    private readonly InputAction m_MovementB_Drop;
    private readonly InputAction m_MovementB_Move;
    private readonly InputAction m_MovementB_Serve;
    public struct MovementBActions
    {
        private @PlayerControls m_Wrapper;
        public MovementBActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pick => m_Wrapper.m_MovementB_Pick;
        public InputAction @Drop => m_Wrapper.m_MovementB_Drop;
        public InputAction @Move => m_Wrapper.m_MovementB_Move;
        public InputAction @Serve => m_Wrapper.m_MovementB_Serve;
        public InputActionMap Get() { return m_Wrapper.m_MovementB; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementBActions set) { return set.Get(); }
        public void SetCallbacks(IMovementBActions instance)
        {
            if (m_Wrapper.m_MovementBActionsCallbackInterface != null)
            {
                @Pick.started -= m_Wrapper.m_MovementBActionsCallbackInterface.OnPick;
                @Pick.performed -= m_Wrapper.m_MovementBActionsCallbackInterface.OnPick;
                @Pick.canceled -= m_Wrapper.m_MovementBActionsCallbackInterface.OnPick;
                @Drop.started -= m_Wrapper.m_MovementBActionsCallbackInterface.OnDrop;
                @Drop.performed -= m_Wrapper.m_MovementBActionsCallbackInterface.OnDrop;
                @Drop.canceled -= m_Wrapper.m_MovementBActionsCallbackInterface.OnDrop;
                @Move.started -= m_Wrapper.m_MovementBActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MovementBActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MovementBActionsCallbackInterface.OnMove;
                @Serve.started -= m_Wrapper.m_MovementBActionsCallbackInterface.OnServe;
                @Serve.performed -= m_Wrapper.m_MovementBActionsCallbackInterface.OnServe;
                @Serve.canceled -= m_Wrapper.m_MovementBActionsCallbackInterface.OnServe;
            }
            m_Wrapper.m_MovementBActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pick.started += instance.OnPick;
                @Pick.performed += instance.OnPick;
                @Pick.canceled += instance.OnPick;
                @Drop.started += instance.OnDrop;
                @Drop.performed += instance.OnDrop;
                @Drop.canceled += instance.OnDrop;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Serve.started += instance.OnServe;
                @Serve.performed += instance.OnServe;
                @Serve.canceled += instance.OnServe;
            }
        }
    }
    public MovementBActions @MovementB => new MovementBActions(this);
    public interface IMovementAActions
    {
        void OnPick(InputAction.CallbackContext context);
        void OnDrop(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnServe(InputAction.CallbackContext context);
    }
    public interface IMovementBActions
    {
        void OnPick(InputAction.CallbackContext context);
        void OnDrop(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnServe(InputAction.CallbackContext context);
    }
}
