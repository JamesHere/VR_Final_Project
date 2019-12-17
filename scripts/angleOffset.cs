using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angleOffset : MonoBehaviour
{
    public GameObject Player;
    Vector3 targetDirection;
    void Start()
    {
        Player = GameObject.Find("camera");
        targetDirection = Player.transform.position;
        transform.LookAt(targetDirection);
        Destroy(this.gameObject, 1);
    }

    void Update()
    {
        
    }
}
