using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    private StateContainer stateContainer;
    private long NTPOffset;
    private List<string> dataList;
    public bool recording = false;

    // Start is called before the first frame update
    void Start()
    {
        stateContainer = GameObject.Find("StateContainer").GetComponent<StateContainer>();
        NTPOffset = stateContainer.NTPOffset;
        dataList = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        if (recording)
        {
            dataList.Add(GetTrueTime().ToString() + "," +
                transform.position.x + "," +
                transform.position.y + "," +
                transform.position.z + "\r\n");

            //Debug.Log(GetTrueTime().ToString() + ": " + transform.position);
        }
    }

    long GetTrueTime()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - NTPOffset;
    }

    private string GetDataPath()
    {
        string id = stateContainer.GetComponent<StateContainer>().id;
        return Path.Combine(Application.persistentDataPath, id + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm") + ".csv");
    }

    public void ResetData()
    {
        recording = false;
        dataList = new List<string>();
        stateContainer.ResetID();
    }

    public void SaveDataFile()
    {
        Debug.Log("Data file saved to " + GetDataPath());
        string dataText = "position,x,y,z" + "\r\n";
        foreach (string data in dataList)
        {
            dataText += data;
        }
        File.AppendAllText(GetDataPath(), dataText);
        ResetData();
    }
}
