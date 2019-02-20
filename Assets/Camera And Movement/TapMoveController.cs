using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapMoveController : MonoBehaviour {

	public bool mouseMode;
	Vector3 targetPosition = Vector3.zero;
	public float speed = 10.0f;
	Vector3 offset;

	// Use this for initialization
	void Start () 
	{
		Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2f,Screen.height/2f));
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 10000f))
		{
			offset = this.transform.position - hit.point;
		} 	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (mouseMode)
		{
			//		Debug.Log(Input.mousePosition[0]);
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 10000f))
			{
				targetPosition = hit.point;
			}
		}
		else
		{
			if ( Input.touchCount > 0)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit, 10000f))
				{
					targetPosition = hit.point;
				}
			}
		}
	}

	void LateUpdate ()
	{
		this.transform.position = Vector3.MoveTowards( this.transform.position, targetPosition + offset,speed * Time.deltaTime);
	}
}
