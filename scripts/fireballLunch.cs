using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballLunch : MonoBehaviour
{
    float speed = 22;
    public GameObject Player;
    public Rigidbody orb;
    AudioSource audio;
    public Transform lunchPoint;
    float timer = 0;
    float timer2 = 0;
    public int ammo = 5;
    public int status = 1;

    void Start()
    {
        Player = GameObject.Find("camera");
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        //if (Input.GetMouseButtonDown(0))
 
            if (timer >= 1f & status == 1 & Input.GetAxis("AXIS_10") == 1)
            {
                audio.Play();
                Rigidbody clone;
                clone = (Rigidbody)Instantiate(orb, lunchPoint.position, lunchPoint.rotation);
                clone.velocity = transform.TransformDirection(Vector3.forward * speed);
                ammo -= 1;
                if (ammo <= 0)
                {
                    status = 0;
                    timer2 = 0;
                }

                timer = 0;
                timer2 = 0;
            }
            else if (timer2 >= 6f)
            {
                status = 1;
                ammo = 5;
            }

        if (Player.GetComponent<damage>().gameOver == 1)
        {
            Destroy(this.gameObject);
            Destroy(this);
        }
    }
}
