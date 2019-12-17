using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    public int hp = 20;
    Transform damageIndicator;
    public int cnt = 0;
    AudioSource audio;
    public int gameOver = 0;

    void Start()
    {
        damageIndicator = transform.Find("hitIndicator");
        audio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "arrow")
        {
            Destroy(coll.gameObject);
            audio.Play();
            GameObject bloodEffect = Instantiate(Resources.Load("playerDamaged"), damageIndicator.position, Quaternion.identity) as GameObject;
            Destroy(bloodEffect,1);
            hp -= 1;

        }
        if (coll.collider.tag == "thrust")
        {
            Destroy(coll.gameObject);
            audio.Play();
            GameObject bloodEffect = Instantiate(Resources.Load("playerDamaged"), damageIndicator.position, Quaternion.identity) as GameObject;
            Destroy(bloodEffect, 1);
            hp -= 1;

        }
    }

    void Update()
    {
        if (hp <= 0)
        {
            gameOver = 1;
        }

    }
}
