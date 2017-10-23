using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallTrackerUI_Script : MonoBehaviour {

	public GameObject Ball;
	public GameObject Cam;
	public GameObject ChildCounter;
	public float CamLimitX;
	private CanvasRenderer Cr;
	private float UIRatio;
	private float ScaleRatio;
	private CanvasRenderer Cr2;
	private Image Im;
	//private Ball_Script BallScript;
	private SpriteRenderer BallSr;
	private Color BallColor;

	// Use this for initialization
	void Start () {
		Cr = this.GetComponent<CanvasRenderer> ();
		Cr2 = ChildCounter.GetComponent<CanvasRenderer> ();
		Im = this.GetComponent<Image> ();
		//BallScript = Ball.GetComponent<Ball_Script> ();
		BallSr = Ball.GetComponent<SpriteRenderer> ();
		UIRatio = Screen.height/10; //Replace stric values
	}
	
	// Update is called once per frame
	void Update () {
		BallColor = BallSr.color;
		Im.color = BallColor;
		if (Ball.transform.position.x > Cam.transform.position.x + CamLimitX) {
			Cr.SetAlpha (1);
			Cr2.SetAlpha (1);
			ScaleRatio = Ball.transform.position.x - Cam.transform.position.x;
			this.transform.position = new Vector2 (Screen.width-Screen.width/10, Ball.transform.position.y * UIRatio + Screen.height/2); //Replace strict values with relativ screen.width/length
			this.transform.localScale = new Vector2 (4 / Mathf.Abs(ScaleRatio), 4 / Mathf.Abs(ScaleRatio));
		} 
		else if (Ball.transform.position.x < Cam.transform.position.x - CamLimitX) {
			Cr.SetAlpha (1);
			Cr2.SetAlpha (1);
			ScaleRatio =  Cam.transform.position.x - Ball.transform.position.x;
			this.transform.position = new Vector2 (Screen.width/10, Ball.transform.position.y * UIRatio + Screen.height/2); //Replace strict values
			this.transform.localScale = new Vector2 (4 / Mathf.Abs(ScaleRatio), 4 / Mathf.Abs(ScaleRatio));
		} 
		else {
			Cr.SetAlpha (0);
			Cr2.SetAlpha (0);
		}
	}
}
