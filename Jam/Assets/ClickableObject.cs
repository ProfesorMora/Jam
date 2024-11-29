using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
	        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        	RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

			if (hit.collider != null)
 	       {
 	           Debug.Log($"Hit detected on object: {hit.collider.name}");
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
