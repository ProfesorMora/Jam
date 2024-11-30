using System.Collections.Generic;
using UnityEngine;

public class formScript : MonoBehaviour
{
    public GameObject formPanel;
    public GameObject submitButton;
    public List<GameObject> textBoxesList;
    public List<GameObject> buttonsList;
    public DialogManager dialogManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        formPanel.SetActive(false);
        submitButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogManager.deactivated) formPanel.SetActive(true);
    }

    
}
