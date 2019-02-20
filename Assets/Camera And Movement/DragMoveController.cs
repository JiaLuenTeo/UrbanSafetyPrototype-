using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMoveController : MonoBehaviour {

	public bool useMouse;
	public Vector3 direction;
	float magnitude;
	Vector3 lastMousePos;
	public float baseSpeed = 10.0f;

	// Use this for initialization
	void Start () 
	{
		lastMousePos = Input.mousePosition;
	}
	
	// Update is called once per frame
	void Update () {
		if (useMouse)
		{
			MouseDrag();
		}
		else
		{
			TouchDrag();
		}
		
	}

	void MouseDrag()
	{
		if (Input.GetMouseButton(0))
		{
			direction = (Input.mousePosition - lastMousePos).normalized;

		}
			
		lastMousePos = Input.mousePosition;
	}

	void TouchDrag()
	{
		if (Input.touchCount > 0)
		{
			direction = Input.touches[0].deltaPosition.normalized;
			magnitude = Input.touches[0].deltaPosition.magnitude;
		}
	}

	void LateUpdate()
	{
		Vector3 worldDir = new Vector3( direction.x,0,direction.y);
		this.transform.Translate(-worldDir *Time.deltaTime*baseSpeed* magnitude,Space.World);
	}
}
