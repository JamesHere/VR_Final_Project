using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSpawner : MonoBehaviour
{
    public GameObject melee;
    float timer = 0;
    public GameObject Player;
    float num;
    void Start()
    {
        //InvokeRepeating("spawnMelee", 5, 5);
        Player = GameObject.Find("camera");
    }

    void spawnMelee()
    {
        num = Random.Range(0, 4);
        if (num >= 0 & num < 1)
        {
            Instantiate(melee, new Vector3(Random.Range(-26.6f, -20.5f), 4, Random.Range(-10.5f, -2.5f)), Quaternion.identity);
        }
        else if (num >= 1 & num < 2)
        {
            Instantiate(melee, new Vector3(Random.Range(19.9f, 26f), 4, Random.Range(-10f, -3f)), Quaternion.identity);
        }
        else if (num >=2 & num < 3)
        {
            Instantiate(melee, new Vector3(Random.Range(-2.5f, 2.2f), 4, Random.Range(15f, 10f)), Quaternion.identity);
        }
        else
        {
            Instantiate(melee, new Vector3(Random.Range(-8f, 9f), 4, Random.Range(-18f, -17f)), Quaternion.identity);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 8)
        {
        timer = 0;
        spawnMelee();
        }
        if (Player.GetComponent<damage>().gameOver == 1)
        {
            Destroy(this.gameObject);
            Destroy(this);
        }
    }
}
