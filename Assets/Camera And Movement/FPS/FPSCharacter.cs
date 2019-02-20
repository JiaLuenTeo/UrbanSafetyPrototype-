using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCharacter : MonoBehaviour {

	public float walkspeed = 3f;


	public void Move(Vector3 _direction)
	{
		this.transform.Translate(-_direction * walkspeed * Time.deltaTime);
	}
}
