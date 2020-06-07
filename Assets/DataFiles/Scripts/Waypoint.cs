using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Color exploredColor;
    private bool isExplored = false;
    Vector3Int gridPos;
    const int GridSize = 11;
    public Waypoint exploredFrom;

    public bool isPlaceable = true;

    InputActions inputActions;
    Vector2 mousePosition;
    bool leftClick = false;

    private void Awake()
    {
        inputActions = new InputActions();
        inputActions.ActionMap.MousePosition.performed += ctx => mousePosition = ctx.ReadValue<Vector2>();
        inputActions.ActionMap.MouseClick.performed += ctx => leftClick = ctx.performed;
    }


    public bool IsExplored
    {
        get => isExplored;
        set
        {
            isExplored = value;

        }
    }
    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / GridSize),
            Mathf.RoundToInt(transform.position.z / GridSize)
            );
    }

    public int GetGridSize()
    {
        return GridSize;
    }


    private void OnMouseOver()
    {
        if (leftClick) {
            leftClick = false;
            if (isPlaceable)
            {
                print("Placeable block");
            }
            else
            {
                print("Not a placeable block");
            }
        }
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
