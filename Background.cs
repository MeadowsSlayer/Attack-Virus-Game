using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

	public int time;
	private float speed = 1f;
	private Rigidbody2D myBody;

	void Start () {
		myBody = GetComponent<Rigidbody2D> ();
	}
	void Update () {
		time++;
		if (time>=480){
			transform.position = new Vector2 (Random.Range(-50f, -25f), Random.Range(-7f,7f));
			time=0;
		}
		Vector3 move = new Vector3 (6, 0, 0);
		myBody.velocity = move * speed;
	}
}
