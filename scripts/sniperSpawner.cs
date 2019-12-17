using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sniperSpawner : MonoBehaviour
{
    public GameObject sniper;
    float timer = 0;

    void Start()
    {
        Invoke("firstBatch1", 5);
        Invoke("firstBatch2", 8);

    }

    void firstBatch1()
    {
        Instantiate(sniper, new Vector3(3.77f, 12.62f, 13.99f),Quaternion.identity);
        
    }
    void firstBatch2()
    {
        Instantiate(sniper, new Vector3(-3.98f, 12.62f, 13.99f), Quaternion.identity);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 30)
        {
            Invoke("firstBatch1", 1);
            Invoke("firstBatch2", 4);
            timer = 0;
        }   
    }
}
