using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDefence : MonoBehaviour
{
    int life = 100;

    public void Hit(int hit)
    {
        life -= hit;
        var fxGameObject = gameObject.transform.Find("HitFX");
        var fx = fxGameObject.GetComponent<ParticleSystem>();
        fx.Play();
    }

}
