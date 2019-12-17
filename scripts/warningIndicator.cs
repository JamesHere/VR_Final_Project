using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warningIndicator : MonoBehaviour
{

    void Start()
    {

    }


    void normal()
    {
        GetComponent<TextMesh>().text = " vxvf ";
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "arrow")
        {
            GameObject danger = Instantiate(Resources.Load("wei_character"), this.transform.position, Quaternion.identity) as GameObject;
            Destroy(danger, 1);
        }
        if (coll.collider.tag == "enemy")
        {
            GameObject danger = Instantiate(Resources.Load("wei_character"), this.transform.position, Quaternion.identity) as GameObject;
            Destroy(danger, 1);
        }


    }

    void Update()
    {



    }
}
