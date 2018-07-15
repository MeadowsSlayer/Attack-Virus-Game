using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour {

	public CursorScr cur;
	public GameObject load;
	public int time = 0;
	public int health = 5;
	public GameObject explosion;

	void Start () {
		cur = GameObject.Find ("Cursor").GetComponent<CursorScr>();
	}

	void FixedUpdate () {
		time++;
		if(time>=20){
			time = 0;
			Instantiate (load, new Vector3 (transform.position.x-0.2f, transform.position.y-0.2f, -1), Quaternion.identity);
		}
		if (health <= 0) {
			cur.score+=5;
			Instantiate (explosion, new Vector3 (transform.position.x, transform.position.y, -1), Quaternion.identity);
			Destroy(this.gameObject, 0.02f);
		}
	}
	private void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Bullet" || collider.tag == "BulletRight" || collider.tag == "BulletLeft"){
			Destroy (collider.gameObject);
			health -= 1;
		}
	}
}
