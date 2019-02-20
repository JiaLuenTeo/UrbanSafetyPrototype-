using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchZoom : MonoBehaviour {

	float initDistance;
	float curDistance;
	public float speed = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.touchCount == 2)
		{
			if (Input.touches[1].phase == TouchPhase.Began)
			{
				initDistance = Vector3.Distance(Input.touches[0].position, Input.touches[1].position);
				print("Got init distance " + initDistance );
			}

			curDistance = Vector3.Distance(Input.touches[0].position, Input.touches[1].position);

			float direction = curDistance/ initDistance;
			direction = direction - 1f;

			this.transform.Translate(Vector3.forward * Time.deltaTime * direction* speed, Space.Self);

		}	
	}
}
