using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickableObject : MonoBehaviour
{
	public GameObject text;
	public Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
	        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        	RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

			if (hit.collider)
 	       {
				Debug.Log($"Hit detected on object: {hit.collider.name}");
				text.SetActive(true);
 	       }
 	       else
 	       {
 	           Debug.Log("No hit detected.");
  	 	   }
		}
    }

    void OnMouseDown()
    {
    }
}
