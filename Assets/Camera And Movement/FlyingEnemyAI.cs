using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyAI : MonoBehaviour {

	public GameObject target;
	public float distanceToPlayer = 40;
	public float speed = 10;
	public float killTime = 10;

	Color lockonColor = Color.black;
	Renderer rend;

	// Use this for initialization
	void Start () 
	{
		rend = GetComponent<Renderer>();
		rend.material.shader = Shader.Find("Standard");
		rend.material.color = lockonColor;
		target = GameObject.FindGameObjectWithTag("Player");	
	}
	
	// Update is called once per frame
	void Update () 
	{
		CheckY();
	}

	void CheckY()
	{
		if (transform.position.y < 20.0f)
		{
			transform.position += new Vector3(0, 1.0f,0) * Time.deltaTime;
		}
		else 
		{
			FlyToTarget();	
		}
	}

	void FlyToTarget()
	{
		float distance;
		float movementSpeed;

		distance = Vector3.Distance(target.transform.position,this.transform.position);
		movementSpeed = distanceToPlayer * (Time.deltaTime * speed/100);


		if (distance > distanceToPlayer)
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position,target.transform.position,movementSpeed);
		}
	}

	public void timeToKill()
	{
		float oriTime = killTime;
		killTime -= Time.deltaTime;

		lockonColor.r += (1 / killTime) * Time.deltaTime;
		rend.material.color = lockonColor;

		if (killTime <= 0)
		{
			killTime = oriTime;
			Destroy(gameObject);
		}
	}
}
