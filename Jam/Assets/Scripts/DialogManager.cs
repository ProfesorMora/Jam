using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;

    private void Start()
    {
        
    }

    
    public void showDialog(string text)
    {
        dialogBox.SetActive(true);
        dialogText.text = text; 
    }
}