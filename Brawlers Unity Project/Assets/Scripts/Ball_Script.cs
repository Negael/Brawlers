using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Script : MonoBehaviour {

	private Rigidbody2D Rb;
	private TrailRenderer Tr;
	private SpriteRenderer Sr;
	public float BallPower = 0;
	private float BallVelocity = 5;
	private PlayerStats_Script PlayerScript;
	private GameObject InvisiWall;

	// Use this for initialization
	void Start () {
		Rb = this.GetComponent<Rigidbody2D> ();
		Tr = this.GetComponent<TrailRenderer> ();
		Sr = this.GetComponent<SpriteRenderer> ();
		InvisiWall = GameObject.Find ("WallMiddle");
		Physics2D.IgnoreCollision (InvisiWall.GetComponent<Collider2D> (), this.GetComponent<Collider2D> ());
	}
	
	// Update is called once per frame
	void Update () {
		Rb.velocity = Rb.velocity.normalized * BallVelocity;
	}

	// When Hit
	void OnCollisionEnter2D(Collision2D Coll){
		Tr.startColor = new Color (0, 127, 127);
		Tr.endColor = new Color (0, 0, 255);
		Sr.color = new Color (0.2f, 0.8f, 1f);
		if (Coll.gameObject.tag == "player") {
			//PlayerScript = Coll.gameObject.GetComponent<PlayerStats_Script> ();
			//BallVelocity = PlayerScript.StrikeForce;
		}
	}
}
