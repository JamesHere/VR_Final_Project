using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordThrust : MonoBehaviour
{
    public GameObject Player;
    Vector3 targetDirection;
    void Start()
    {
        Player = GameObject.Find("camera");
        targetDirection = Player.transform.position;
        transform.LookAt(targetDirection);
        this.GetComponent<Rigidbody>().AddForce(transform.forward * 600);
        Destroy(this.gameObject, 0.6f);

    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "sword")
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        
    }
}
