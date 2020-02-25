using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    private Recorder recorder;

    // Start is called before the first frame update
    void Start()
    {
        recorder = GameObject.Find("Main Camera").GetComponent<Recorder>();
    }

    // Update is called once per frame
    void Update()
    { 
    
    }
        
    public void StartRecord()
    {
        Debug.Log("Start recording...");
        recorder.recording = true;
        GameObject.Find("StateContainer").GetComponent<StateContainer>().SetButtonActive(true);
    }

    public void StopRecord()
    {
        Debug.Log("Stop recording...");
        recorder.recording = false;
    }

    public void SaveData()
    {
        Debug.Log("Saving...");
        recorder.SaveDataFile();
    }

    public void ResetData()
    {
        Debug.Log("Resetting...");
        recorder.ResetData();
    }
}
