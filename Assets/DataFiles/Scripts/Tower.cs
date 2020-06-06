using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] GameObject projectileGameObject;
    ParticleSystem projectile;
    [SerializeField] float attackRange = 5f;

    private void Start()
    {
        projectile = projectileGameObject.GetComponent<ParticleSystem>();
        print(projectile);
    }
    void Update()
    {
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            Shoot();
        }
        

    }

    void Shoot()
    {
        if (Vector3.Distance(targetEnemy.transform.position, transform.position)/11 < attackRange) //todo 11 deve ser substituido pelo gridsize
        {      
            if(!projectile.isEmitting)
                projectile.Play();
        }
        else
        {
            if(projectile.isEmitting)
                projectile.Stop();
        }

    }
}
