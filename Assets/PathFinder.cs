using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] Waypoint StartWaypoint, EndWaypoint;
    Queue<Waypoint> queue = new Queue<Waypoint>();

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left,
    };

    void Start()
    {
        LoadBloks();
        ColorStartAndEndPoint();
        ExploreNeighbours();
        PathFind();


    }

    public void PathFind()
    {
        queue.Enqueue(StartWaypoint);
        //print("Entered: " + queue.Count) ;
        while (queue.Count > 0)
        {
            var searchingCenter = queue.Dequeue();
            if (searchingCenter.Equals(EndWaypoint))
            {
                print("Found! ");
            }
            
            
        }
    }

    public void ExploreNeighbours()
    {
        foreach (var item in directions)
        {
            Vector2Int explorationCoordinates = StartWaypoint.GetGridPos() + item;
            if (grid.ContainsKey(explorationCoordinates))
            {
                grid[explorationCoordinates].SetTopColor(Color.blue);
            }
            
        } 
    }

    private void ColorStartAndEndPoint()
    {
        StartWaypoint.SetTopColor(Color.green);
        EndWaypoint.SetTopColor(Color.red);
    }


    private void LoadBloks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();

        foreach (var item in waypoints)
        {

            var gridPos = item.GetGridPos() * item.GetGridSize();
            bool isOverlapping = grid.ContainsKey(gridPos);
            //overlaping blocks
            //add to dictionary
            
            if (isOverlapping)
            {
                print("Skipping overlapping block: "+ gridPos);
            }
            else
            {
                //print(item.GetGridPos());
                grid.Add(item.GetGridPos(), item);
            
            }
           
        }
        //print("Loaded " + grid.Count + " blocks");




        //print(grid);





    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
