using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TPSLookController : MonoBehaviour , IDragHandler, IEndDragHandler {

	public float rotSpeed = 10f;

	RectTransform rect;
	Vector3 originPos;
	Vector3 direction;
//	float viewAngle = 0f;

	public Transform rootTransform;
//	public Transform camTransform;
//	public Transform lookTarget;

	// Use this for initialization
	void Start () 
	{
		rect = GetComponent<RectTransform>();	
		originPos = this.rect.position;
	}

	public void OnDrag(PointerEventData eventData)
	{
		rect.position = eventData.position;
		direction = this.rect.position - originPos;
		direction.Normalize();
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		rect.position = originPos;
//		direction = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//rootTransform.Rotate(Vector3.up * direction.x * rotSpeed * Time.deltaTime, Space.World);

		//camTransform.Rotate(Vector3.right * direction.y * rotSpeed * Time.deltaTime,Space.World);

//		viewAngle += direction.y * Time.deltaTime * 90f;
//		viewAngle = Mathf.Clamp(viewAngle,-40f,40f);
//		camTransform.localEulerAngles = new Vector3 (-viewAngle,0f,0f);

		//camTransform.rotation = Quaternion.Lerp(camTransform.rotation, lookTarget.rotation, Time.deltaTime * rotSpeed);

		float angles = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		rootTransform.eulerAngles = new Vector3( 0f, -angles+90f, 0f);
	}
}
