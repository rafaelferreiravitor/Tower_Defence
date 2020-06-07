using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{

    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerLimit = 5;
    [SerializeField] List<Tower> towers = new List<Tower>();
    [SerializeField] Queue<Tower> towerQueue = new Queue<Tower>();



    public void AddTower(Waypoint waypoint)
    {
        if (towerQueue.Count < towerLimit)
        {
            InstantiateNewTower(waypoint);
        }
        else
        {
            MoveExistingTower(waypoint);
        }
    }

    private void InstantiateNewTower(Waypoint waypoint)
    {
        var tower = Instantiate(towerPrefab, waypoint.transform.position, Quaternion.identity);
        tower.transform.SetParent(gameObject.transform);
        tower.baseWaypoint = waypoint;
        towerQueue.Enqueue(tower);
        waypoint.isPlaceable = false;

    }

     void MoveExistingTower(Waypoint waypoint)
    {
        var oldTower = towerQueue.Dequeue();
        oldTower.baseWaypoint.isPlaceable = true;
        oldTower.transform.position = waypoint.transform.position;
        oldTower.baseWaypoint = waypoint;
        oldTower.baseWaypoint.isPlaceable = false;
        towerQueue.Enqueue(oldTower);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
