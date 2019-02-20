using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCharacter : MonoBehaviour {

	public float walkspeed = 3f;


	public void Move(Vector3 _direction)
	{
		this.transform.Translate(-_direction * walkspeed * Time.deltaTime,Space.World);
	}
}
