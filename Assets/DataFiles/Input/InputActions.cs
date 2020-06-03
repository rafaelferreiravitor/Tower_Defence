// GENERATED AUTOMATICALLY FROM 'Assets/DataFiles/Input/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""ActionMap"",
            ""id"": ""4a1f1c78-72e7-4cf6-bcd6-28a5ab7294a2"",
            ""actions"": [
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""c2898c57-8c90-4e87-b2e8-c8f54dd65756"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""64866ea7-a16a-4b91-9b70-5f74fe8fb982"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""83bb7bff-1835-4425-91ca-23cb5f1bedb5"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55ee1a76-a127-4179-b9d5-f07ca9c7eafa"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ActionMap
        m_ActionMap = asset.FindActionMap("ActionMap", throwIfNotFound: true);
        m_ActionMap_MousePosition = m_ActionMap.FindAction("MousePosition", throwIfNotFound: true);
        m_ActionMap_MouseClick = m_ActionMap.FindAction("MouseClick", throwIfNotFound: true);
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

    // ActionMap
    private readonly InputActionMap m_ActionMap;
    private IActionMapActions m_ActionMapActionsCallbackInterface;
    private readonly InputAction m_ActionMap_MousePosition;
    private readonly InputAction m_ActionMap_MouseClick;
    public struct ActionMapActions
    {
        private @InputActions m_Wrapper;
        public ActionMapActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @MousePosition => m_Wrapper.m_ActionMap_MousePosition;
        public InputAction @MouseClick => m_Wrapper.m_ActionMap_MouseClick;
        public InputActionMap Get() { return m_Wrapper.m_ActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IActionMapActions instance)
        {
            if (m_Wrapper.m_ActionMapActionsCallbackInterface != null)
            {
                @MousePosition.started -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMousePosition;
                @MouseClick.started -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMouseClick;
                @MouseClick.performed -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMouseClick;
                @MouseClick.canceled -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMouseClick;
            }
            m_Wrapper.m_ActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @MouseClick.started += instance.OnMouseClick;
                @MouseClick.performed += instance.OnMouseClick;
                @MouseClick.canceled += instance.OnMouseClick;
            }
        }
    }
    public ActionMapActions @ActionMap => new ActionMapActions(this);
    public interface IActionMapActions
    {
        void OnMousePosition(InputAction.CallbackContext context);
        void OnMouseClick(InputAction.CallbackContext context);
    }
}
