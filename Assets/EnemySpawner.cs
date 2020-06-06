using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyMovement EnemyPrefab;
    [SerializeField] List<EnemyMovement> Enemies = new List<EnemyMovement>();
    [SerializeField] float secondsBetweenSpawns = 2f;

    private void Awake()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            Enemies.Add(Instantiate(EnemyPrefab));
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
