using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpMonitor : MonoBehaviour
{
    int m_hp;
    int m_cnt;
    GameObject temp;
    GameObject temp2;

    private TextMesh textMesh;
    void Start()
    {
        temp = GameObject.Find("camera");
        temp2 = GameObject.Find("MixedRealityPlayspace");
        textMesh = gameObject.GetComponentInChildren<TextMesh>();
        temp2.transform.position = new Vector3(0f, 2f, 0f);
    }

    void OnEnable()
    {

        Application.logMessageReceived += LogMessage;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= LogMessage;
    }

    public void LogMessage(string message, string stackTrace, LogType type)
    {
        // Set the text 
        textMesh.text = message;
    }

    void Update()
    {
        m_hp = temp.GetComponent<damage>().hp;
        m_cnt = temp.GetComponent<damage>().cnt;
        GetComponent<TextMesh>().text = string.Format("HP: {0} / 15                               Kill Count: {1}", m_hp, m_cnt);
        //Debug.Log(string.Format("HP: {0} / 15                               Kill Count: {1}", m_hp,m_cnt));
        if (m_hp <= 0)
        {
            GetComponent<TextMesh>().text = string.Format("GAME OVER                              Final Score: {0}", m_cnt);
            Destroy(this);
        }
    }
}
