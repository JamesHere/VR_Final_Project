using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeArrow : MonoBehaviour
{

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "arrow")
        {
            Destroy(coll.gameObject);

        }
        if (coll.collider.tag == "orb")
        {
            Destroy(coll.gameObject);

        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
