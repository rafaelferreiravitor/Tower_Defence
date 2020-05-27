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
    bool isRunning = true;
    Waypoint searchCenter; // current search center


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
        //ExploreNeighbours();
        PathFind();

    }

    public void PathFind()
    {
        queue.Enqueue(StartWaypoint);

        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
   
            HaltItIfItFound();
            ExploreNeighbours();



        }
    }

    private void HaltItIfItFound()
    {
        if (searchCenter.Equals(EndWaypoint))
        {
            print("Found! ");
            isRunning = false;
        }
    }

    public void ExploreNeighbours()
    {
        if (!isRunning) return;

        foreach (var item in directions)
        {
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + item;
            if (grid.ContainsKey(neighbourCoordinates))
            {
                QueueNewNeighbour(neighbourCoordinates);
            }

        } 
    }

    private void QueueNewNeighbour(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        if (grid[neighbourCoordinates].IsExplored || queue.Contains(neighbour))
        {
            
            
        }
        else
        {
            //neighbour.SetTopColor(Color.blue); // todo move later
            neighbour.exploredFrom = searchCenter;
            neighbour.IsExplored = true; //todo Marking as explored // check if it need to be at the end after explore neighbour // maybe it makes sense to have it when it is enqueued
            queue.Enqueue(neighbour);
            print("Queuing " + neighbour.name);

            //print("Queuing " + neighbour.isExplored);
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
