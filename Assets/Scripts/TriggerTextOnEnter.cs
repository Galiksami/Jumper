using UnityEngine;
using TMPro;

public class TriggerTextOnEnter : MonoBehaviour
{
    public string messageToShow = "Welcome to the empty object!";
    public TextMeshProUGUI textMeshProUI;
    public float displayDuration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (textMeshProUI != null)
            {
                textMeshProUI.text = messageToShow;
                textMeshProUI.gameObject.SetActive(true);

                
                Invoke("HideText", displayDuration);
            }
            else
            {
                Debug.LogError("TextMeshProUGUI component not assigned to the script.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            HideText();
        }
    }

    private void HideText()
    {
        
        if (textMeshProUI != null)
        {
            textMeshProUI.gameObject.SetActive(false);
            CancelInvoke("HideText");
        }
    }
}
