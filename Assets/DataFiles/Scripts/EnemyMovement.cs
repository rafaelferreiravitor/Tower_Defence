using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    int life = 4;

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
        
        yield return new WaitForSeconds(1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Hit on trigger");

    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Hit on collision");
        life--;
        EnemyDamaged();
    }

    private void EnemyDamaged()
    {
        if (life <= 2)
        {
            var gameObjectDamaged = transform.Find("DeathFX").Find("Damaged");
            var damaged = gameObjectDamaged.GetComponent<ParticleSystem>();
            damaged.Play();
        }
        if (life <= 2)
        {
            var gameObjectDestoyed = transform.Find("DeathFX").Find("Destroyed");
            var destoyed = gameObjectDestoyed.GetComponent<ParticleSystem>();
            destoyed.Play();
            Invoke("EnemyDeath", 1);

            
        }
    }

    void EnemyDeath()
    {
        Destroy(this);
        print("Here");
    }
}
