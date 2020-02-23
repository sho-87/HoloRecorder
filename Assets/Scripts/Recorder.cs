using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    private GameObject stateContainer;
    private Vector3 position;
    private DateTimeOffset timeUTC;
    private long systemTime;

    // Start is called before the first frame update
    void Start()
    {
        stateContainer = GameObject.Find("StateContainer");

        // Get system time in milliseconds
        timeUTC = DateTimeOffset.UtcNow;
        systemTime = timeUTC.ToUnixTimeMilliseconds();

        Debug.Log("System time: " + systemTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (stateContainer.GetComponent<StateContainer>().recording)
        {
            position = transform.position;
            Debug.Log(position);
        }
    }

}
