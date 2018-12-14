using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float maxSpeed;
    public float engineForce;
    Rigidbody rBody;
    public float carLength;
	// Use this for initialization
	void Start () {
        rBody = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 transformRight = -Vector3.Cross(transform.up, -transform.forward);
		Vector3 wheelDirection = transform.forward + 0.75f*(Input.GetAxis("Left_Stick_X")*transformRight);
        float deltaDistance;

        float rightTrigger = Input.GetAxis("Right_Trigger");
		if (rBody.velocity.magnitude<maxSpeed&&rightTrigger>0.5f) {
				rBody.AddForce(rightTrigger * wheelDirection* engineForce*Mathf.Log(-rBody.velocity.magnitude+maxSpeed));
		}
		float leftTrigger = Input.GetAxis("Left_Trigger");
		if (rBody.velocity.magnitude<maxSpeed&&leftTrigger>0.5f) {
				rBody.AddForce(-leftTrigger * wheelDirection* engineForce*Mathf.Log(-rBody.velocity.magnitude+maxSpeed));
        }
        deltaDistance = Time.deltaTime * rBody.velocity.magnitude;

        transform.forward = transform.forward+(rBody.velocity.magnitude/maxSpeed)*Time.deltaTime*wheelDirection;
    }
	
}
