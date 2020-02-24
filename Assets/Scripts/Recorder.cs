using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    private StateContainer stateContainer;
    private Vector3 position;
    private long NTPOffset;

    // Start is called before the first frame update
    void Start()
    {
        stateContainer = GameObject.Find("StateContainer").GetComponent<StateContainer>();
        NTPOffset = stateContainer.NTPOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (stateContainer.recording)
        {
            position = transform.position;

            Debug.Log(GetTrueTime().ToString() + ": " + position);
        }
    }

    long GetTrueTime()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - NTPOffset;
    }

}
