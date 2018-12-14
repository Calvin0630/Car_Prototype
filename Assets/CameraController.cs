using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject target;
	float height =45;
	float trailingDistance = 80;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 deltaPos = trailingDistance*-target.transform.forward + height*target.transform.up;
		transform.position =target.transform.position + deltaPos;
		transform.LookAt(target.transform);
	}
}
