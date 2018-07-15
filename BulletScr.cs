using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScr : MonoBehaviour {

	public float speed = 1f;
	private Rigidbody2D myBody;

	void Start () {
		myBody = GetComponent<Rigidbody2D> ();
	}


	void FixedUpdate () {
		if (this.gameObject.tag == "Bullet") {
			Vector3 move = new Vector3 (0, 1, 0);
			myBody.velocity = move * speed;
		}
		if (this.gameObject.tag == "BulletLeft") {
			Vector3 move = new Vector3 (Random.Range(-1, -0.25f), 1, 0);
			myBody.velocity = move * speed;
		}
		if (this.gameObject.tag == "BulletRight") {
			Vector3 move = new Vector3 (Random.Range(0.25f, 1), 1, 0);
			myBody.velocity = move * speed;
		}

		Destroy(this.gameObject, 1.0f);
	}
	private void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag != "Cursor" && collider.tag!="Bullet" && collider.tag!="BulletLeft" && collider.tag!="BulleRight" && collider.tag!="Bug") {
			Destroy (this.gameObject);
		}
	}
}
