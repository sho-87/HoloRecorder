using System;
using TMPro;
using UnityEngine;

public class StateContainer : MonoBehaviour
{
    public string id;
    public GameObject idInput;
    public long NTPOffset = 0;
    public GameObject startButton;
    public GameObject stopButton;
    public GameObject saveButton;
    public GameObject resetButton;

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

        // Disable buttons initially
        SetButtonActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetID()
    {
        idInput.GetComponent<TMP_InputField>().text = "";
        id = "";
        SetButtonActive(false);
    }

    public void SetButtonActive(bool state)
    {
        startButton.SetActive(state);
        stopButton.SetActive(state);
        saveButton.SetActive(state);
        resetButton.SetActive(state);
    }
}
