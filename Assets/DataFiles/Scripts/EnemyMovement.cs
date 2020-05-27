using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> Path;

    private void Start()
    {
        //StartCoroutine(PlayPath());
    }

    IEnumerator PlayPath()
    {

        foreach (var item in Path)
        {
            gameObject.transform.position = item.GetComponent<Transform>().position;
            yield return new WaitForSeconds(1f);
        }
        
        yield return new WaitForSeconds(1f);
    }
}
