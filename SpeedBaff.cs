using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBaff : MonoBehaviour {

	public CursorScr cur;
	public float speed = 2f;
	public int health = 5;
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
		Vector3 move = new Vector3 (0, -1, 0);
		myBody.velocity = move * speed;

		if (health <= 0) {
			Destroy(this.gameObject, 0.02f);
			Instantiate (explosion, new Vector3 (transform.position.x, transform.position.y, -1), Quaternion.identity);
			if (gameObject.tag != "SpeedBaff" && gameObject.tag != "Antivirus banner" && gameObject.tag != "MultiM" && gameObject.tag != "MultiShot" && gameObject.tag != "TripleShot" && gameObject.tag != "TwinShot") {
				cur.score++;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Bullet" || collider.tag == "BulletRight" || collider.tag == "BulletLeft"){
			Destroy (collider.gameObject);
			health -= 1;
		}
		if (collider.tag == "Barier"){
			Destroy (this.gameObject);
		}
	}
}
