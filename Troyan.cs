using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troyan : MonoBehaviour {

	public CursorScr cur;
	public GameObject virus;
	public float speed = 2f;
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
		Destroy(this.gameObject, 25f);
		Vector3 move = new Vector3 (-0.75f, 0, 0);
		myBody.velocity = move * speed;
	}

	private void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Bullet" || collider.tag == "BulletRight" || collider.tag == "BulletLeft"){
			for(int c = 0; c < 15; c++){
				Instantiate (virus, new Vector3 (transform.position.x + Random.Range(-5f, 5f), transform.position.y + Random.Range(-5f, 5f), -1), Quaternion.identity);
			}
			Instantiate (explosion, new Vector3 (transform.position.x-1f, transform.position.y + 0.25f, -2), Quaternion.identity);
			Destroy(this.gameObject, 0.02f);
		}
	}
}
