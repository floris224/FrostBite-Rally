// GENERATED AUTOMATICALLY FROM 'Assets/Ash Vehicle Physics/Scripts/carInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CarInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CarInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""carInputs"",
    ""maps"": [
        {
            ""name"": ""carAction"",
            ""id"": ""d0e29681-3071-440b-b9a8-e57cbfaab2d8"",
            ""actions"": [
                {
                    ""name"": ""moveH"",
                    ""type"": ""PassThrough"",
                    ""id"": ""cf26ad67-3c17-46da-b059-a5fa749e3b59"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""moveV"",
                    ""type"": ""Button"",
                    ""id"": ""47f7ebdb-f761-49ec-bec2-e73de38d5330"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""brake"",
                    ""type"": ""Button"",
                    ""id"": ""574b4719-547c-452e-a5c4-936e1e9eaad7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""up_down"",
                    ""type"": ""Button"",
                    ""id"": ""8711f2c9-d960-4b04-a38c-4ea13b35c2a5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ControllerMove"",
                    ""type"": ""Value"",
                    ""id"": ""23eac683-714c-4c2c-91e7-84b1b2ab836f"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""horizontal"",
                    ""id"": ""27c57255-1364-439d-bc03-2ffaf17684e3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press"",
                    ""processors"": ""Clamp(min=-2,max=2)"",
                    ""groups"": """",
                    ""action"": ""moveH"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""b3a06630-26e9-47c7-b349-1faadbc91118"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveH"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""8938f0d9-2869-4a20-b70b-43b97fc061d6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveH"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""vertical"",
                    ""id"": ""b82acc53-5620-4a87-bbd7-993a693edfea"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveV"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6b6861e5-0afd-4eac-bf1e-b1283d8df1a6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveV"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""c9017e01-a7df-4e25-ac3b-47912787e978"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveV"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""jump"",
                    ""id"": ""e2473e23-d0a2-4d81-868d-c25a09f69c64"",
                    ""path"": ""1DAxis(minValue=0)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""brake"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""aae99b0e-8e1b-44dc-b6b9-61b861e73c33"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""681fb416-648f-4479-965c-6f3b7a1319e0"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""yAxis"",
                    ""id"": ""52313d49-7efb-4988-a074-e91ef7b27e42"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""up_down"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0210850f-52f2-449f-aa69-6c84ed0270fa"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""up_down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ed7ae927-b92f-4b96-92ca-610d7fc24cd8"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""up_down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Vector 2"",
                    ""id"": ""990473ba-92da-41a3-aa4a-f107116a86e9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ControllerMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""eebd9924-455d-4579-b007-02bcbd2ec1dc"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ControllerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2eb8abb4-eb19-4afa-8a2d-a508fe3b0e2f"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ControllerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""56ef3511-e929-4c1a-b5f4-292ba2d1e70c"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ControllerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""96c04b30-afee-4f3b-ac5a-bf6855f76840"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ControllerMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // carAction
        m_carAction = asset.FindActionMap("carAction", throwIfNotFound: true);
        m_carAction_moveH = m_carAction.FindAction("moveH", throwIfNotFound: true);
        m_carAction_moveV = m_carAction.FindAction("moveV", throwIfNotFound: true);
        m_carAction_brake = m_carAction.FindAction("brake", throwIfNotFound: true);
        m_carAction_up_down = m_carAction.FindAction("up_down", throwIfNotFound: true);
        m_carAction_ControllerMove = m_carAction.FindAction("ControllerMove", throwIfNotFound: true);
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

    // carAction
    private readonly InputActionMap m_carAction;
    private ICarActionActions m_CarActionActionsCallbackInterface;
    private readonly InputAction m_carAction_moveH;
    private readonly InputAction m_carAction_moveV;
    private readonly InputAction m_carAction_brake;
    private readonly InputAction m_carAction_up_down;
    private readonly InputAction m_carAction_ControllerMove;
    public struct CarActionActions
    {
        private @CarInputs m_Wrapper;
        public CarActionActions(@CarInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @moveH => m_Wrapper.m_carAction_moveH;
        public InputAction @moveV => m_Wrapper.m_carAction_moveV;
        public InputAction @brake => m_Wrapper.m_carAction_brake;
        public InputAction @up_down => m_Wrapper.m_carAction_up_down;
        public InputAction @ControllerMove => m_Wrapper.m_carAction_ControllerMove;
        public InputActionMap Get() { return m_Wrapper.m_carAction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CarActionActions set) { return set.Get(); }
        public void SetCallbacks(ICarActionActions instance)
        {
            if (m_Wrapper.m_CarActionActionsCallbackInterface != null)
            {
                @moveH.started -= m_Wrapper.m_CarActionActionsCallbackInterface.OnMoveH;
                @moveH.performed -= m_Wrapper.m_CarActionActionsCallbackInterface.OnMoveH;
                @moveH.canceled -= m_Wrapper.m_CarActionActionsCallbackInterface.OnMoveH;
                @moveV.started -= m_Wrapper.m_CarActionActionsCallbackInterface.OnMoveV;
                @moveV.performed -= m_Wrapper.m_CarActionActionsCallbackInterface.OnMoveV;
                @moveV.canceled -= m_Wrapper.m_CarActionActionsCallbackInterface.OnMoveV;
                @brake.started -= m_Wrapper.m_CarActionActionsCallbackInterface.OnBrake;
                @brake.performed -= m_Wrapper.m_CarActionActionsCallbackInterface.OnBrake;
                @brake.canceled -= m_Wrapper.m_CarActionActionsCallbackInterface.OnBrake;
                @up_down.started -= m_Wrapper.m_CarActionActionsCallbackInterface.OnUp_down;
                @up_down.performed -= m_Wrapper.m_CarActionActionsCallbackInterface.OnUp_down;
                @up_down.canceled -= m_Wrapper.m_CarActionActionsCallbackInterface.OnUp_down;
                @ControllerMove.started -= m_Wrapper.m_CarActionActionsCallbackInterface.OnControllerMove;
                @ControllerMove.performed -= m_Wrapper.m_CarActionActionsCallbackInterface.OnControllerMove;
                @ControllerMove.canceled -= m_Wrapper.m_CarActionActionsCallbackInterface.OnControllerMove;
            }
            m_Wrapper.m_CarActionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @moveH.started += instance.OnMoveH;
                @moveH.performed += instance.OnMoveH;
                @moveH.canceled += instance.OnMoveH;
                @moveV.started += instance.OnMoveV;
                @moveV.performed += instance.OnMoveV;
                @moveV.canceled += instance.OnMoveV;
                @brake.started += instance.OnBrake;
                @brake.performed += instance.OnBrake;
                @brake.canceled += instance.OnBrake;
                @up_down.started += instance.OnUp_down;
                @up_down.performed += instance.OnUp_down;
                @up_down.canceled += instance.OnUp_down;
                @ControllerMove.started += instance.OnControllerMove;
                @ControllerMove.performed += instance.OnControllerMove;
                @ControllerMove.canceled += instance.OnControllerMove;
            }
        }
    }
    public CarActionActions @carAction => new CarActionActions(this);
    public interface ICarActionActions
    {
        void OnMoveH(InputAction.CallbackContext context);
        void OnMoveV(InputAction.CallbackContext context);
        void OnBrake(InputAction.CallbackContext context);
        void OnUp_down(InputAction.CallbackContext context);
        void OnControllerMove(InputAction.CallbackContext context);
    }
}
