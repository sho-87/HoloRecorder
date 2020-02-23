using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Microsoft.MixedReality.Toolkit.Experimental.UI
{
/// <summary>
/// This component links the NonNativeKeyboard to a TMP_InputField
/// Put it on the TMP_InputField and assign the NonNativeKeyboard.prefab
/// </summary>
[RequireComponent(typeof(TMP_InputField))]
    public class Keyboard : MonoBehaviour, IPointerDownHandler
    {
        [Experimental]
        [SerializeField] private NonNativeKeyboard keyboard = null;
        public GameObject menu;
        private GameObject stateContainer;

        void Start()
        {
            stateContainer = GameObject.Find("StateContainer");
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            menu.SetActive(false);
            keyboard.PresentKeyboard();

            keyboard.OnClosed += DisableKeyboard;
            keyboard.OnTextSubmitted += DisableKeyboard;
            keyboard.OnTextUpdated += UpdateText;
        }

        private void UpdateText(string text)
        {
            GetComponent<TMP_InputField>().text = text;
        }

        private void DisableKeyboard(object sender, EventArgs e)
        {
            stateContainer.GetComponent<StateContainer>().id = GetComponent<TMP_InputField>().text;
            menu.SetActive(true);
            keyboard.OnTextUpdated -= UpdateText;
            keyboard.OnClosed -= DisableKeyboard;
            keyboard.OnTextSubmitted -= DisableKeyboard;
            
            keyboard.Close();
        }
    }
}