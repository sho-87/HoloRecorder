using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    public GameObject stateContainer;
    private long NTPOffset;
    private List<string> dataList;
    public bool recording = false;

    // Start is called before the first frame update
    void Start()
    {
        NTPOffset = stateContainer.GetComponent<StateContainer>().NTPOffset;
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
                transform.position.z);

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
        stateContainer.GetComponent<StateContainer>().ResetID();
    }

    public void SaveDataFile()
    {
        Debug.Log("Data file saved to " + GetDataPath());

        using (TextWriter tw = new StreamWriter(GetDataPath()))
        {
            string header = "time,x,y,z";
            tw.WriteLine(header);

            for (int i = 0; i < dataList.Count; i++)
            {
                tw.WriteLine(dataList[i]);
            }
                
        }
        ResetData();
    }
}
