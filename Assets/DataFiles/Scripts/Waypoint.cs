﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Color exploredColor;
    private bool isExplored = false;
    Vector3Int gridPos;
    const int GridSize = 11;
    public Waypoint exploredFrom;

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
        print("dsadsadas");
    }


    
}
