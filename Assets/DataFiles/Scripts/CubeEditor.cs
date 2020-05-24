using System.Collections;
using System.Collections.Generic;
using System.Numerics;
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
        transform.position = new UnityEngine.Vector3(
            waypoint.GetGridPos().x * waypoint.GetGridSize(),
            0,
            waypoint.GetGridPos().y * waypoint.GetGridSize()
            );
    }

    private void UpdateLabel()
    {
        textMesh = GetComponentInChildren<TextMesh>();
        string labelText = waypoint.GetGridPos().x + "," + waypoint.GetGridPos().y ;
        textMesh.text = labelText;
        gameObject.name = "Waypoint (" + labelText + ")";
    }
}
