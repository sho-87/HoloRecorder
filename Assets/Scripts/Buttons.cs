using UnityEngine;

public class Buttons : MonoBehaviour
{
    private StateContainer stateContainer;
    private Recorder recorder;

    // Start is called before the first frame update
    void Start()
    {
        stateContainer = GameObject.Find("StateContainer").GetComponent<StateContainer>();
        recorder = GameObject.Find("Main Camera").GetComponent<Recorder>();
    }

    // Update is called once per frame
    void Update()
    { 
    
    }
        
    public void StartRecord()
    {
        Debug.Log("Start recording...");
        stateContainer.recording = true;
    }

    public void StopRecord()
    {
        Debug.Log("Stop recording...");
        stateContainer.recording = false;
    }

    public void SaveData()
    {
        Debug.Log("Saving...");
        recorder.SaveDataFile();
    }

    public void DeleteData()
    {
        Debug.Log("Deleting...");
        recorder.CreateTempFile();
    }
}
