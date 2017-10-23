using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysicTest_Script : MonoBehaviour {

	private Rigidbody2D RB2D;
	public float Force = 5;

	// Use this for initialization
	void Start () {
		RB2D = this.gameObject.GetComponent<Rigidbody2D>();
		//RB2D.AddForce(transform.up * Force);
		RB2D.AddForce(new Vector2(Force, Force/2));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
