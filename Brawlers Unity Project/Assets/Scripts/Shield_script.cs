using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_script : MonoBehaviour {

	private Vector3 StartSize;
	private Vector3 ChangeSize;
	public float ReductionRatio = 0.25f;
	public int ShieldLife = 3;

	// Use this for initialization
	void Start () {
		StartSize = this.transform.localScale;
		ChangeSize = this.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag != this.gameObject.tag) {
			ChangeSize = new Vector3 (ChangeSize.x - ReductionRatio, ChangeSize.y - ReductionRatio, 0);
			this.transform.localScale = ChangeSize;
			ShieldLife -= 1;
			if (ShieldLife == 0) {
				Destroy (this.gameObject);
			}
		}
	}
}
