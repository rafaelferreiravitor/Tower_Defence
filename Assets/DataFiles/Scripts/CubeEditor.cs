using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    [SerializeField] [Range(1f, 20f)] float GridSize;

    TextMesh textMesh;

    private void Start()
    {

        
    }
    void Update()
    {
        Vector3 snap;
        snap.x = Mathf.RoundToInt(transform.position.x / GridSize)* GridSize;
        snap.y = 0;
        snap.z = Mathf.RoundToInt(transform.position.z / GridSize) * GridSize;
        transform.position = snap;
        textMesh = GetComponentInChildren<TextMesh>();
        string labelText = snap.x / GridSize + "," + snap.z / GridSize;
        textMesh.text = labelText;
        gameObject.name = "Waypoint ("+labelText+")";
    }
}
