using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    Vector3Int gridPos;
    const int GridSize = 11;

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

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
}
