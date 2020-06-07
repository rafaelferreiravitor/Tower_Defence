using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int fullLife = 100;
    int remainingLife = 100;
    [SerializeField] int hitPoints = 10;
    bool alive = true;

    private void Awake()
    {
        remainingLife = fullLife;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (alive)
        {
            ProcessHit();
            EnemyDamaged();
        }
        
    }

    private void ProcessHit()
    {
        remainingLife -= hitPoints;
    }

    private void EnemyDamaged()
    {
        if (remainingLife <= 0)
        {
            var gameObjectDestoyed = transform.Find("DeathFX").Find("Destroyed");
            var destoyed = gameObjectDestoyed.GetComponent<ParticleSystem>();
            destoyed.Play();
            alive = false;
            Destroy(gameObject, 3);
            //Invoke("KillEnemy", 3);

        }
        else if (remainingLife <= fullLife * 0.70)
        {
            var gameObjectDamaged = transform.Find("DeathFX").Find("Damaged");
            var damaged = gameObjectDamaged.GetComponent<ParticleSystem>();
            damaged.Play();
        }
        
    }

}
