using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowFlying : MonoBehaviour
{
    public GameObject Player;
    //public float Speed = 10f;
    Vector3 targetDirection;
    AudioSource audio;
    public AudioClip deflectSound;

    void Start()
    {
        Player = GameObject.Find("camera");
        targetDirection = Player.transform.position;
        transform.LookAt(targetDirection);
        this.GetComponent<Rigidbody>().AddForce(transform.forward * 300);
        Destroy(this.gameObject, 6);
        AudioSource[] audioSources = GetComponents<AudioSource>();
        audio = audioSources[0];
        deflectSound = audioSources[0].clip;
    }


    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "sword")
        {
            this.transform.gameObject.tag = "deflect";
            this.GetComponent<Rigidbody>().AddForce(transform.forward * -800);
            GameObject deflectEffect = Instantiate(Resources.Load("Deflect_Effect"), this.transform.position, Quaternion.identity) as GameObject;
            audio.PlayOneShot(deflectSound);
            Destroy(deflectEffect, 1);
            //Destroy(this.gameObject);

        }

    }

    void Update()
    {
        if (Player.GetComponent<damage>().gameOver == 1)
        {
            Destroy(this.gameObject);
            Destroy(this);
        }

    }
}
