using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementPeriod = 1f;

    private void Start()
    {
        PathFinder pathFinder = GameObject.FindObjectOfType<PathFinder>();

        var path = pathFinder.GetPath();
        
        StartCoroutine(PlayPath(path));
    }
    
    IEnumerator PlayPath(List<Waypoint> path)
    {

        foreach (var item in path)
        {
            gameObject.transform.position = item.GetComponent<Transform>().position;
            yield return new WaitForSeconds(1f);
        }
        SelfDestroy();
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
