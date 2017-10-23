using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot_Script : MonoBehaviour {
	
	private Rigidbody2D Rb;
	private Vector2 PointDown;
	private Vector2 PointUp;
	private Vector2 Force;
	private LineRenderer Lr;
	private ParticleSystem Ps;
	private bool ClickDown = false;
	public float FrictionFactor = 0.9f;
	private Vector3 RelativePosition;
	private float MouseDistance;
	private PlayerStats_Script StatScript;

	// Use this for initialization
	void Start () {
		ClickDown = false;
		Rb = this.transform.GetComponent<Rigidbody2D> ();
		Lr = this.transform.GetComponent<LineRenderer> ();
		Ps = this.transform.GetComponent<ParticleSystem> ();
		StatScript = this.transform.GetComponent<PlayerStats_Script> ();
		Ps.enableEmission = false;
	}
	
	// Update is called once per frame
	void Update () {
		RelativePosition = this.transform.position - Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion rotation = Quaternion.LookRotation(RelativePosition, Vector3.back);
		MouseDistance = ((Vector3.Distance (this.transform.position, Camera.main.ScreenToWorldPoint (Input.mousePosition)))/1000)*StatScript.MoveSpeed*15;
		if (ClickDown == true) {
			Ps.enableEmission = true;
			Ps.startLifetime = MouseDistance;
			Lr.SetPosition (0, this.transform.position);
			Lr.SetPosition (1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
			this.transform.rotation = new Quaternion (0, 0, rotation.z, rotation.w);
		}
		else {
			Ps.enableEmission = false;
			Lr.SetPosition(0, new Vector2(0,0));
			Lr.SetPosition(1, new Vector2(0,0));
		}
		Rb.velocity = Rb.velocity * FrictionFactor;
	}

	void OnMouseDown () {
		ClickDown = true;
		Rb.velocity = new Vector2 (0, 0);
		PointDown = new Vector2 (this.transform.position.x, this.transform.position.y);
		//Debug.Log ("Entry point" + PointDown);
	}

	void OnMouseUp () {
		ClickDown = false;
		PointUp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//Debug.Log ("Exit point" + PointUp);
		Force = PointDown - PointUp;
		Rb.AddForce (Force * StatScript.MoveSpeed*10);
		Rb.angularVelocity = 0;
	}

	void OnCollisionEnter2D (Collision2D coll){
		//Debug.Log ("Hit");
		Rb.velocity = Rb.velocity/2;
		Time.timeScale = 0.2f;
		StartCoroutine (WaitAndRescaleTime(0.1f));
	}

	IEnumerator WaitAndRescaleTime(float Delay){
		yield return new WaitForSeconds(Delay);
		Time.timeScale = 1f;
	}
}