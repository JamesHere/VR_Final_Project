using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo : MonoBehaviour
{
    GameObject temp;
    private TextMesh textMesh;
    int ammoCnt;
    int flag;

    void Start()
    {
        temp = GameObject.Find("wandMagic");
        textMesh = gameObject.GetComponentInChildren<TextMesh>();
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
        //message = "charging";
        textMesh.text = message;
    }

    void Update()
    {
        flag = temp.GetComponent<fireballLunch>().status;
        ammoCnt = temp.GetComponent<fireballLunch>().ammo;
        if (flag == 1)
        {
            GetComponent<TextMesh>().text = string.Format("{0}", ammoCnt);
        }
        else
        {
            GetComponent<TextMesh>().text = "Charging";
        }

    }
}
