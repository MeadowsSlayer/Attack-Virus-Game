using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipVirus : MonoBehaviour {

	public CursorScr cur;
	public float speed = 1f;
	private Rigidbody2D myBody;
	public GameObject explosion;

	void Start () {
		cur = GameObject.Find ("Cursor").GetComponent<CursorScr>();
		myBody = GetComponent<Rigidbody2D> ();
	}


	void FixedUpdate () {
		if (cur.istime == true) {
			speed = 0.25f;
		} else {
			speed = 1f;
		}
		Vector3 move = new Vector3 (Random.Range(-10, 10), -0.5f, 0);
		myBody.velocity = move * speed;
	}

	private void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Bullet" || collider.tag == "BulletRight" || collider.tag == "BulletLeft") {
			cur.score++;
			Instantiate (explosion, new Vector3 (transform.position.x, transform.position.y, -1), Quaternion.identity);
			Destroy (this.gameObject, 0.02f);
		}
	}
}
