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
            var startPos = GameObject.FindObjectOfType<PathFinder>().transform;
            EnemyMovement enemy = Instantiate(EnemyPrefab,startPos.position, new Quaternion());
            enemy.gameObject.transform.SetParent(gameObject.transform);
            Enemies.Add(enemy);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
