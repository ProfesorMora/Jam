using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class formScript : MonoBehaviour
{
    public GameObject formPanel;
    public GameObject submitButton;
    public DialogManager dialogManager;
    public List<TMP_InputField> listOfInputs;
    public ToggleGroup toggleGroupPet; // Esto no lo pilla el formScript
    public ToggleGroup toggleGroupWork; //
    public Canvas priceCanvas;
    public TextMeshProUGUI priceText;
    bool formSubmitted;

    List<bool> listOfToggleBools;
    List<int> listOfToggleValues;
    int petSelection;
    int bloodSelection;
    int workSelection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        formPanel.SetActive(false);
        submitButton.SetActive(false);
        priceCanvas.enabled = false;
        listOfToggleBools = new List<bool>{false, false, false};
        listOfToggleValues = new List<int>{0,0,0};
        formSubmitted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!formSubmitted)
        {
            if(dialogManager.deactivated) formPanel.SetActive(true);
            if(isFormFilled()) submitButton.SetActive(true);
        }
    }

    public bool isFormFilled()
    {
        foreach(var b in listOfToggleBools)
        {
            if(!b) return false;
        }

        return true;
    }

    public void assign(string where, int what)
    {
        if(where == "pet") petSelection = what;
        if(where == "blood") bloodSelection = what;
        if(where == "work") workSelection = what;
    }

    public void petSelected()
    {
        listOfToggleBools[0] = true;
    }

    public void bloodSelected()
    {
        listOfToggleBools[1] = true;
    }

    public void workSelected()
    {
        listOfToggleBools[2] = true;
    }

    public void submitForm()
    {
        if(!formSubmitted)
        {
            Debug.Log("Will submit form");
            formPanel.SetActive(false);
            priceText.text = calculatePrice().ToString() + "€";
            priceCanvas.enabled = true;
            formSubmitted = true;
        }else{
            priceCanvas.enabled = false;
            submitButton.SetActive(false);
            changeScene();
        }
    }

    int calculatePrice()
    {
        int currentPrice = 0;
        foreach( Toggle toggle in toggleGroupPet.ActiveToggles() )
        {
            if(toggle.name == "togGatos") currentPrice -= 300;
            if(toggle.name == "togPerros") currentPrice += 300;
        }

        foreach( Toggle toggle in toggleGroupWork.ActiveToggles() )
        {
            if(toggle.name == "togIndefinido") currentPrice -= 300;
            if(toggle.name == "togTemporal") currentPrice += 300;
        }

        currentPrice -= 150;

        Debug.Log("Current Price: " + currentPrice);

        return currentPrice;
    }

    void changeScene()
    {
        Debug.Log("Will change scene");
        //SceneManager.LoadScene(2);
    }
}
