using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseDefence : MonoBehaviour
{
    [SerializeField] int life = 100;

    private void Awake()
    {
        UpdateUI();
    }

    void Hit(int hit)
    {
        life -= hit;
        HitFx();
        UpdateUI();
    }

    private void UpdateUI()
    {
        var canvas = FindObjectOfType<GraphicRaycaster>();
        var baseHealthText = canvas.transform.Find("BaseHealthText");
        baseHealthText.GetComponent<Text>().text = life.ToString();

    }

    private void HitFx()
    {
        var fxGameObject = gameObject.transform.Find("HitFX");
        var fx = fxGameObject.GetComponent<ParticleSystem>();
        transform.GetComponent<AudioSource>().Play();
        fx.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        print("enter");
        var enemy = other.GetComponent<EnemyDamage>();
        Hit(enemy.remainingLife);
    }

}
