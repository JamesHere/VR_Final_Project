using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeSpawner : MonoBehaviour
{
    public GameObject range;
    float timer = 0;
    float num;
    void Start()
    {
        //InvokeRepeating("spawnMelee", 5, 5);
    }

    void spawnMelee()
    {
        num = Random.Range(0, 3);
        if (num >= 0 & num < 1)
        {
            Instantiate(range, new Vector3(Random.Range(-16f, -12f), 4, Random.Range(-12f, 0.38f)), Quaternion.identity);
        }
        else if (num >= 1 & num < 2)
        {
            Instantiate(range, new Vector3(Random.Range(9.3f, 15.75f), 4, Random.Range(-14.55f, 1.75f)), Quaternion.identity);
        }
        else
        {
            Instantiate(range, new Vector3(Random.Range(-8f, 9f), 4, Random.Range(-18f, -17f)), Quaternion.identity);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 12)
        {
            timer = 0;
            spawnMelee();
        }
    }
}
