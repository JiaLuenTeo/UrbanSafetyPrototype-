using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragToMove : MonoBehaviour {

	Vector3 targetPos;
	Vector3 moveDelta;
	public float speed = 100;
	float rawInertia;
	float inertia;
	float inertiatime = 0f;

	// Use this for initialization
	void Start () 
	{
		targetPos = this.transform.position;
		moveDelta = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () 
	{
		InputTargetPosition();	
		MoveCamera();
	}

	void InputTargetPosition()
	{
		if (Input.touchCount > 0)
		{
			if (Input.touches[0].phase == TouchPhase.Moved)
			{
				rawInertia = Input.touches[0].deltaPosition.magnitude;
				inertia = rawInertia;
				inertiatime = 0f;

				moveDelta.x = Input.touches[0].deltaPosition.x;
				moveDelta.y = Input.touches[0].deltaPosition.y;
			}
			else if (Input.touches[0].phase == TouchPhase.Ended)
			{
				if (inertia > 0f)
				{
					if (inertiatime < 1f) inertia -= Time.deltaTime;
					else inertiatime = 1f;

					inertia = Mathf.Lerp (rawInertia, 0f,inertiatime);
				}
				else 
				{
					inertia = 0f;
				}

			}
		}
	}

	void MoveCamera()
	{
		this.transform.Translate(-moveDelta * Time.deltaTime * speed * inertia,Space.World);
	}
}
