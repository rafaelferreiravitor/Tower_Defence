using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] Transform objectToPan;
    [SerializeField] GameObject projectileGameObject;
    ParticleSystem projectile;
    [SerializeField] float attackRange = 5f;

    public Waypoint baseWaypoint;

    Transform targetEnemy;

    private void Start()
    {
        projectile = projectileGameObject.GetComponent<ParticleSystem>();
        

    }
    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            Shoot();
        }


    }

    private void SetTargetEnemy()
    {
        var enemies = FindObjectsOfType<EnemyMovement>();
        if (enemies != null)
        {
            EnemyMovement closestEnemy = FindClosest(enemies);
            targetEnemy = closestEnemy.transform;
        }
        else
        {
            targetEnemy = null;
        }
    }

    private EnemyMovement FindClosest(EnemyMovement[] enemies)
    {
        var closestEnemy = enemies[0];
        foreach (var item in enemies)
        {
            if (Vector3.Distance(item.transform.position, transform.position) < Vector3.Distance(closestEnemy.transform.position, transform.position))
            {
                closestEnemy = item;
            }
        }

        return closestEnemy;
    }

    void Shoot()
    {
        if (Vector3.Distance(targetEnemy.transform.position, transform.position)/11 < attackRange) //todo 11 deve ser substituido pelo gridsize
        {
            if (!projectile.isEmitting)
            {
                projectile.Play();
            }
        }
        else
        {
            if(projectile.isEmitting)
                projectile.Stop();
        }

    }
}
