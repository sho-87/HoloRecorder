using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    private StateContainer stateContainer;
    private long NTPOffset;
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        stateContainer = GameObject.Find("StateContainer").GetComponent<StateContainer>();
        NTPOffset = stateContainer.NTPOffset;
        CreateTempFile();
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

    private void OnApplicationQuit()
    {
        File.Delete(GetTempPath());
    }

    long GetTrueTime()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - NTPOffset;
    }

    private string GetTempPath()
    {
        return Path.Combine(Application.persistentDataPath, "temp.csv");
    }

    private string GetDataPath()
    {
        string id = stateContainer.GetComponent<StateContainer>().id;
        return Path.Combine(Application.persistentDataPath, "data", id + "_" + System.DateTime.Now.ToString("yyyy_MM_dd_HH_mm") + ".csv");
    }

    public void CreateTempFile()
    {
        // https://nielson.dev/2015/09/saving-games-in-unity

        Debug.Log("Creating temp file at " + GetTempPath());

        stateContainer.ResetID();

        try
        {
            Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "data"));

            using (FileStream fs = File.Create(GetTempPath()))
            {
                byte[] header = new UTF8Encoding(true).GetBytes("time,position");
                fs.Write(header, 0, header.Length);
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    public void SaveDataFile()
    {
        Debug.Log("Data file saved to " + GetDataPath());
        File.Copy(GetTempPath(), GetDataPath());
        CreateTempFile();
    }
}
