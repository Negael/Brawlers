using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest_Script : MonoBehaviour {

	public GameObject Ball;
	public float SmoothFactor = 1;
	public float LimitX;
	private Vector3 TempVect3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(Ball.transform.position.x, this.transform.position.y, -10), Time.deltaTime * SmoothFactor);
		if (this.transform.position.x > LimitX) {
			this.transform.SetPositionAndRotation (new Vector3 (LimitX, this.transform.position.y, -10), this.transform.rotation);
		}
		if (this.transform.position.x < -LimitX) {
			this.transform.SetPositionAndRotation (new Vector3 (-LimitX, this.transform.position.y, -10), this.transform.rotation);
		}
	}
}
