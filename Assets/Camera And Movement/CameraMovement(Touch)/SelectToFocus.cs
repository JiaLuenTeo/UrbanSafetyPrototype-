using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectToFocus : MonoBehaviour {

	public Vector3 targetPos;
	public float speed = 10;
	Vector3 offset;

	// Use this for initialization
	void Start () 
	{
		offset = GetOffSet();
		targetPos = this.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		InputTargetPosition();
		GoToTargetPosition();

	}

	Vector3 GetOffSet()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay ( new Vector3((float)Screen.width/2f,(float)Screen.height/2f,0f));
		if ( Physics.Raycast( ray,out hit,10000f))
		{
			return this.transform.position - hit.point;
		}
		else return Vector3.zero;
	}

	void InputTargetPosition()
	{
		if( Input.touchCount > 0)
		{
			if (Input.touches[0].phase == TouchPhase.Began)
			{
				print(Input.touches[0].position);

				Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);

				RaycastHit hit;

				if ( Physics.Raycast( ray,out hit,10000f))
				{
					Debug.Log(hit.point);
					targetPos = hit.point + offset;
				}
				else 
				{
					Debug.Log("Nothing to hit");
				}

			}
		}	
	}



	void GoToTargetPosition()
	{
		if (this.transform.position != targetPos)
		{
			this.transform.position = Vector3.MoveTowards( transform.position,targetPos,Time.deltaTime * speed);
				
		}
	}
}
