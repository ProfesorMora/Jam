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
	bool	isMenu;

	bool	color;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		Debug.Log(GlobalVariables.price);
		DisableText();
		isDestroyed = false;
		color = false;
		isMenu = false;
    }

    // Update is called once per frame
    void Update()
    {
	//	if (color == false)
		//	Sprite.color = Color.red;
		//else
			//Sprite.color = Color.white;
	    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
		CheckColor(hit);
		if (Input.GetMouseButtonDown(0) && hit.collider)
		{
			isMenu = true;
			if (hit.collider && isDestroyed == false)
				EnableText();
		}
    }

	public void DisableText()
	{
		text.SetActive(false);
		YesButton.SetActive(false);
		NoButton.SetActive(false);
		isMenu = false;
	}
	public void YesClick()
	{
		Destroy(text);
		Destroy(YesButton);
		Destroy(NoButton);
		isDestroyed = true;
		isMenu = false;
		GlobalVariables.price -= 400;
		Debug.Log(GlobalVariables.price);
	}

	void EnableText()
	{
		text.SetActive(true);
		YesButton.SetActive(true);
		NoButton.SetActive(true);
	}

	void CheckColor(RaycastHit2D hit)
	{
		if (!isDestroyed)
		{
			if (hit.collider && !isMenu)
				color = true;
			else if (isMenu)
				color = true;
			else
				color = false;
		}
		else
			color = false;

	}
}