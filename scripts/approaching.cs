using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class approaching : MonoBehaviour
{
    // public GameObject Player = GameObject.FindGameObjectWithTag("camera").gameObject;
    //GameObject Player = GameObject.Find("camera");
    public GameObject Player;
    private Animator anim;
    public float movementSpeed = 3f;
    int dead = 0;
    AudioSource audio;
    public AudioClip enemyDead;
    public AudioClip slash;
    float timer = 0;
    Transform attackIndicator;
    int melee_hp = 2;
    //playerStatus m_player;

    void Start()
    {
        //Player = new GameObject("player");
        Player = GameObject.Find("camera");
        attackIndicator = transform.Find("attackIndicator");
        anim = GetComponent<Animator>();
        AudioSource[] audioSources = GetComponents<AudioSource>();
        audio = audioSources[0];
        enemyDead = audioSources[0].clip;
        slash = audioSources[1].clip;
        //m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerStatus>();
        //Player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "orb")
        {
            audio.PlayOneShot(enemyDead);
            dead = 1;
            anim.SetBool("walking", false);
            anim.SetBool("attack", false);
            // anim.SetBool("dead", true);
            GameObject deadEffect = Instantiate(Resources.Load("enemyDead"), this.transform.position, Quaternion.identity) as GameObject;
            Destroy(deadEffect, 1);
            Destroy(coll.gameObject);
            Destroy(this.gameObject);
            Player.GetComponent<damage>().cnt +=1;

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
            if(melee_hp == 0)
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
                melee_hp -= 1;
                GameObject deadEffect = Instantiate(Resources.Load("enemyDead"), this.transform.position, Quaternion.identity) as GameObject;

            }

        }
    }


    void approach()
    {
        Vector3 targetDirection = Player.transform.position;
        targetDirection[1] = transform.position.y;
        transform.LookAt(targetDirection);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
        //yield return new WaitForSeconds(2);

    }

    void playEffect()
    {
        GameObject attackEffect = Instantiate(Resources.Load("meleeDamage"), attackIndicator.position, Quaternion.identity) as GameObject;
        GameObject thrust = Instantiate(Resources.Load("thrust"), attackIndicator.position, Quaternion.identity) as GameObject;
        //Destroy(attackEffect.gameObject, 1);
    }

    void Update()
    {
        timer += Time.deltaTime;
        //Invoke("approach", 2);
        //transform.LookAt(Player.transform);
        //transform.position += transform.forward * movementSpeed * Time.deltaTime;
        if (Vector3.Distance(transform.position, Player.transform.position) < 2.8f)
        {
            if (timer >= 3)
            {
                anim.SetBool("walking", false);
                anim.SetBool("attack", true);
                Invoke("playEffect",0.5f);
                timer = 0;
            }
           
        }
        else if(dead == 0)
        {
            anim.SetBool("walking", true);
            anim.SetBool("attack", false);
            approach();
        }
        if (Player.GetComponent<damage>().gameOver == 1)
        {
            Destroy(this.gameObject);
            Destroy(this);
        }
    }
}