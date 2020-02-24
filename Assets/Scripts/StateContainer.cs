using System;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateContainer : MonoBehaviour
{
    public string id;
    public bool recording = false;
    public long NTPOffset = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Get NTP time
        long ntpTime = NTPClient.GetNetworkTime();
        Debug.Log("NTP time: " + ntpTime);

        // Get system time in milliseconds
        long systemTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        Debug.Log("System time: " + systemTime);

        NTPOffset = systemTime - ntpTime;
        Debug.Log("Time offset: " + NTPOffset);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetID()
    {
        GameObject.Find("InputField (TMP)").GetComponent<TMP_InputField>().text = "";
        id = "";
    }
}
