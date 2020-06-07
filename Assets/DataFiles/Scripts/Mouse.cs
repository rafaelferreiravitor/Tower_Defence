using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    InputActions inputActions;
    Vector2 mousePosition;

    private void Awake()
    {
        inputActions = new InputActions();
        inputActions.ActionMap.MousePosition.performed += ctx => mousePosition = ctx.ReadValue<Vector2>();
        //inputActions.ActionMap.MouseClick.performed += ctx => print("Click in position: "+ mousePosition);
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}


