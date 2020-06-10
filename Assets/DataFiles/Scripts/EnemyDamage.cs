using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    static int numberOfEnemiesAlive = 0;
    [SerializeField] int fullLife = 100;
    public int remainingLife = 100;
    [SerializeField] int hitPoints = 10;
    bool alive = true;
    [SerializeField] AudioClip deathSFX;

    private void Awake()
    {
        remainingLife = fullLife;
        
        numberOfEnemiesAlive++;
        UpdateUI();


    }

     void UpdateUI()
    {
        var canvas = FindObjectOfType<GraphicRaycaster>();
        var enemyText = canvas.transform.Find("EnemyText");
        enemyText.transform.GetComponent<Text>().text = numberOfEnemiesAlive.ToString();
    }

    private void OnDestroy()
    {
        numberOfEnemiesAlive--;
        UpdateUI();
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
        transform.GetComponent<AudioSource>().Play();
        if (remainingLife <= 0)
        {
            var gameObjectDestoyed = transform.Find("DeathFX").Find("Destroyed");
            var destoyed = gameObjectDestoyed.GetComponent<ParticleSystem>();
            destoyed.Play();
            alive = false;

            
            AudioSource.PlayClipAtPoint(deathSFX,Camera.main.transform.position);
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
