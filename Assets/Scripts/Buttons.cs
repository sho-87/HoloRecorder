using UnityEngine;
using TMPro;

public class Buttons : MonoBehaviour
{
    private GameObject stateContainer;
    private Recorder recorder;

    // Start is called before the first frame update
    void Start()
    {
        stateContainer = GameObject.Find("StateContainer");
        recorder = GameObject.Find("Main Camera").GetComponent<Recorder>();
    }

    // Update is called once per frame
    void Update()
    { 
    
    }
        
    public void StartRecord()
    {
        Debug.Log("Start recording...");
        stateContainer.GetComponent<StateContainer>().recording = true;
    }

    public void StopRecord()
    {
        Debug.Log("Stop recording...");
        stateContainer.GetComponent<StateContainer>().recording = false;
    }

    public void SaveData()
    {
        Debug.Log("Saving...");
        GameObject.Find("InputField (TMP)").GetComponent<TMP_InputField>().text = "";
        recorder.SaveDataFile();
    }

    public void DeleteData()
    {
        Debug.Log("Deleting...");
        GameObject.Find("InputField (TMP)").GetComponent<TMP_InputField>().text = "";
        recorder.CreateTempFile();
    }
}
