using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    Vector3Int gridPos;
    const int GridSize = 10;

    public Vector3Int GetGridPos()
    {
        return new Vector3Int(
            Mathf.RoundToInt(transform.position.x / GridSize) * GridSize,
            0,
            Mathf.RoundToInt(transform.position.z / GridSize) * GridSize
            );
    }

    public int GetGridSize()
    {
        return GridSize;
    }

}
