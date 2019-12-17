using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangedAI : MonoBehaviour
{
    public GameObject Player;
    private Animator anim;
    public float movementSpeed = 1f;
    Transform lunchPoint;
    AudioSource audio;
    public AudioClip shooting;
    public AudioClip enemyDead;
    public AudioClip slash;
    Vector3 randomDirection;
    int dead = 0;
    float timer = 0;
    int walking = 1;
    float timer2 = 0;
    int ranger_hp = 2;

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
        slash = audioSources[2].clip;
        randomDirection = new Vector3(Random.Range(-25, 25), transform.position.y, Random.Range(-25, 25));
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
        if (coll.collider.tag == "sword")
        {
            if (ranger_hp == 0)
            {
         
                dead = 1;
                anim.SetBool("walking", false);
                anim.SetBool("attack", false);
                audio.PlayOneShot(enemyDead);
                GameObject deadEffect = Instantiate(Resources.Load("enemyDead"), this.transform.position, Quaternion.identity) as GameObject;
                Destroy(deadEffect, 1);
                Destroy(this.gameObject);
                Player.GetComponent<damage>().cnt += 1;

            }
            else
            {
                audio.PlayOneShot(slash);
                ranger_hp -= 1;
                GameObject deadEffect = Instantiate(Resources.Load("enemyDead"), this.transform.position, Quaternion.identity) as GameObject;

            }

        }
    }
    void walkAround()
    {
        //Vector3 randomDirection = new Vector3(Random.Range(-25, 25), transform.position.y, Random.Range(-25, 25));
        anim.SetBool("walking", true);
        transform.LookAt(randomDirection);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
        walking = 1;

    }

    void delayShoot()
    {
        audio.PlayOneShot(shooting);
        GameObject myRoadInstance = Instantiate(Resources.Load("arrow"), lunchPoint.position, Quaternion.identity) as GameObject;
    }

    void Update()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        //offset += Time.deltaTime;
        if (timer >= 5 & dead == 0 & walking == 0)
        {
            Vector3 targetDirection = Player.transform.position;
            targetDirection[1] = transform.position.y;
            transform.LookAt(targetDirection);
            anim.SetBool("walking", false);
            anim.SetBool("attack", true);
            Invoke("delayShoot", 0.6f);
            randomDirection = new Vector3(Random.Range(-25, 25), transform.position.y, Random.Range(-25, 25));
            timer = 0;
            timer2 = 0;
        }
        if (timer2 >= 3)
        {
            walkAround();
            walking = 0;

        }
        if (Player.GetComponent<damage>().gameOver == 1)
        {
            Destroy(this.gameObject);
            Destroy(this);
        }

    }
}
