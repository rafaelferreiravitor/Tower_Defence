using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
    [SerializeField] [Range(1f, 20f)] float GridSize;

    private void Awake()
    {
        Debug.Log("Awake");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Awake");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(".");
        Vector3 snap;
        snap.x = Mathf.RoundToInt(transform.position.x / GridSize)* GridSize;
        snap.y = 0;
        snap.z = Mathf.RoundToInt(transform.position.z / GridSize) * GridSize;
        transform.position = snap;
    }
}
