using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sniper : MonoBehaviour
{
    public GameObject Player;
    private Animator anim;
    public float movementSpeed = 1f;
    Transform lunchPoint;
    AudioSource audio;
    public AudioClip shooting;
    public AudioClip enemyDead;
    int dead = 0;
    float timer = 0;

    void Start()
    {
        Player = GameObject.Find("camera");
        lunchPoint = transform.Find("lunchPoint");
        anim = GetComponent<Animator>();
        AudioSource[] audioSources = GetComponents<AudioSource>();
        //audio = GetComponent<AudioSource>();
        audio = audioSources[0];
        shooting = audioSources[0].clip;
        enemyDead = audioSources[1].clip;
        Destroy(this.gameObject, 20);
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "orb")
        {
            dead = 1;
            anim.SetBool("walking", false);
            anim.SetBool("attack", false);
            //anim.SetBool("dead", true);
            audio.PlayOneShot(enemyDead);
            GameObject deadEffect = Instantiate(Resources.Load("enemyDead"), this.transform.position, Quaternion.identity) as GameObject;
            Destroy(deadEffect, 1);
            Destroy(coll.gameObject);
            Destroy(this.gameObject);
            Player.GetComponent<damage>().cnt += 1;

        }
        if (coll.collider.tag == "deflect")
        {
            dead = 1;
            anim.SetBool("walking", false);
            anim.SetBool("attack", false);
            audio.PlayOneShot(enemyDead);
            GameObject deadEffect = Instantiate(Resources.Load("enemyDead"), this.transform.position, Quaternion.identity) as GameObject;
            Destroy(deadEffect, 1);
            Destroy(coll.gameObject);
            Destroy(this.gameObject);
            Player.GetComponent<damage>().cnt += 3;

        }
    }

    void delayShoot()
    {
        audio.PlayOneShot(shooting);
        GameObject myRoadInstance = Instantiate(Resources.Load("arrow"), lunchPoint.position, Quaternion.identity) as GameObject;
    }

    void Update()
    {
        Vector3 targetDirection = Player.transform.position;
        targetDirection[1] = transform.position.y;
        transform.LookAt(targetDirection);
        timer += Time.deltaTime;
        //offset += Time.deltaTime;
        if (timer >= 4 & dead == 0)
        {
            timer = 0;
            anim.SetBool("attack", true);
            Invoke("delayShoot", 0.6f);
        }
        if (Player.GetComponent<damage>().gameOver == 1)
        {
            Destroy(this.gameObject);
            Destroy(this);
        }

    }
}
