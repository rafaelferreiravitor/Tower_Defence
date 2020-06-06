using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyMovement EnemyPrefab;
    [SerializeField] List<EnemyMovement> Enemies = new List<EnemyMovement>();
    [SerializeField] [Range(1,10)] int secondsBetweenSpawns = 2;

    private void Awake()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            EnemyMovement enemy = Instantiate(EnemyPrefab);
            enemy.gameObject.transform.SetParent(gameObject.transform);
            Enemies.Add(enemy);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
