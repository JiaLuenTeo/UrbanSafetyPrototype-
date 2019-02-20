using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSController : MonoBehaviour {

	Vector3 origin;
	Vector3 end;

	public List<Transform> selectedUnits;
	Rect rect;
	public Texture texture;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{
			origin = Input.mousePosition;
		}	
		else if (Input.GetMouseButtonUp(0))
		{
			end = Input.mousePosition;

			CheckForUnitsInRect();
		}
	}

	void CheckForUnitsInRect()
	{
		float width = end.x - origin.x;
		float height = end.y - origin.y;

		rect = new Rect(origin.x,origin.y,width,height);


		GameObject[] selectables = GameObject.FindGameObjectsWithTag("Player");

		selectedUnits = new List<Transform>();

		foreach (GameObject go in selectables)
		{
			if (rect.Contains (Camera.main.WorldToScreenPoint(go.transform.position),true))
			{
				selectedUnits.Add(go.transform);
			}
		}
	}

	void OnGUI()
	{
		Rect guiRect = this.rect;
		guiRect.y = Screen.height - guiRect.y;
		guiRect.height *= -1f;
		GUI.DrawTexture(this.rect,texture);
	}

}
