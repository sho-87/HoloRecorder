using UnityEngine;
using TMPro;

public class Buttons : MonoBehaviour
{
    private GameObject stateContainer;

    // Start is called before the first frame update
    void Start()
    {
        stateContainer = GameObject.Find("StateContainer");
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
    }

    public void DeleteData()
    {
        Debug.Log("Deleting...");
        GameObject.Find("InputField (TMP)").GetComponent<TMP_InputField>().text = "";
    }
}
