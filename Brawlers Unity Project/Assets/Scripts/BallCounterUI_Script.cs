using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallCounterUI_Script : MonoBehaviour {

	public GameObject Ball;
	public GameObject Cam;
	private float UIRatioX;
	private float UIRatioY;
	private Ball_Script BScript;
	private float BallPower;
	private Text BallScoreText;

	// Use this for initialization
	void Start () {
		UIRatioY = Screen.height/10; //Change 393 by relativ screen.width
		UIRatioX = Screen.width/5.6f; //Change 221 by relatuv screeb.length
		BScript = Ball.GetComponent<Ball_Script> ();
		BallPower = BScript.BallPower;
		BallScoreText = this.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 ((Ball.transform.position.x - Cam.transform.position.x) * UIRatioX + Screen.width/2, Ball.transform.position.y * UIRatioY + Screen.height/2, -1f);
		BallScoreText.text = BallPower.ToString();
	}
}
