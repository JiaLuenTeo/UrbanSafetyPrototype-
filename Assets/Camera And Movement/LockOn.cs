using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOn : MonoBehaviour {

	public FlyingEnemyAI enemy;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		raycastToHit();
	}

	void raycastToHit()
	{
		Ray ray;
		RaycastHit hit;

		ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0.0f));
		if (Physics.Raycast(ray,out hit))
		{
			print(hit.collider.name);
			if (hit.collider.gameObject.tag == "Enemy")
			{
				enemy = hit.collider.transform.gameObject.GetComponent<FlyingEnemyAI>();
				enemy.timeToKill();
			}

		}
	}
}
