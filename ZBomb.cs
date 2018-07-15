using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZBomb : MonoBehaviour {

	public int time=0;
	public GameObject zvirus;
	public GameObject explosion;

	void Update () {
		time++;
		if (time >= 180) {
			for(int c = 0; c < 30; c++){
				Instantiate (zvirus, new Vector3 (transform.position.x + Random.Range(-5f, 5f), transform.position.y + Random.Range(-5f, 5f), -1), Quaternion.identity);
			}
			Instantiate (explosion, new Vector3 (transform.position.x-1f, transform.position.y + 0.25f, -2), Quaternion.identity);
			Destroy(this.gameObject, 0.02f);
		}
	}
}
