using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[SelectionBase]
[RequireComponent (typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    TextMesh textMesh;
    Waypoint waypoint;


    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }
    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        transform.position = waypoint.GetGridPos();
    }

    private void UpdateLabel()
    {
        textMesh = GetComponentInChildren<TextMesh>();
        string labelText = waypoint.GetGridPos().x / waypoint.GetGridSize() + "," + waypoint.GetGridPos().z / waypoint.GetGridSize();
        textMesh.text = labelText;
        gameObject.name = "Waypoint (" + labelText + ")";
    }
}
