using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickableObject : MonoBehaviour
{
	public GameObject text;
	public GameObject YesButton;
	public GameObject NoButton;
	bool	isDestroyed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		DisableText();
		isDestroyed = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
	        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        	RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

			if (hit.collider && isDestroyed == false)
				EnableText();
		}
    }

	public void DisableText()
	{
		text.SetActive(false);
		YesButton.SetActive(false);
		NoButton.SetActive(false);
	}
	public void YesClick()
	{
		Destroy(text);
		Destroy(YesButton);
		Destroy(NoButton);
		isDestroyed = true;
	}

	void EnableText()
	{
		text.SetActive(true);
		YesButton.SetActive(true);
		NoButton.SetActive(true);
	}
}