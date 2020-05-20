using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Block> Path;

    int i = 0;

    private void Start()
    {
        InvokeRepeating("PlayPath",1,1);
        
    }

    public void PlayPath()
    {
        gameObject.transform.position = Path[i].GetComponent<Transform>().position;
        Debug.Log(Path[i].GetComponent<Transform>().position.ToString());
        if (i < Path.Count-1)
            i++;
    }
}
