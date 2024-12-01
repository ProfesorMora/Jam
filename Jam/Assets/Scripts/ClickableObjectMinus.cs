using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickableObjectMinus : MonoBehaviour
{
	public GameObject text;
	public GameObject YesButton;
	public GameObject NoButton;
	public GameObject Signal;

	public DialogManager dialogManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		Signal.SetActive(true);
		DisableText();
    }

    // Update is called once per frame
	public void DisableText()
	{
		text.SetActive(false);
		YesButton.SetActive(false);
		NoButton.SetActive(false);
		Signal.SetActive(true);
	}
	public void YesClick()
	{
		Destroy(Signal);
		Destroy(text);
		Destroy(YesButton);
		Destroy(NoButton);
		GlobalVariables.price -= 300;
	}

	public void EnableText()
	{
		text.SetActive(true);
		YesButton.SetActive(true);
		NoButton.SetActive(true);
		Signal.SetActive(false);
	}
}