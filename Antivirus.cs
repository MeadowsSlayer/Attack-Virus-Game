using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antivirus : MonoBehaviour {

	public int hp = 4;

	void Update () {
		if (hp <= 0) {
			Destroy(this.gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Virus" || collider.tag == "Load" || collider.tag == "Bug"){
			hp -= 1;
		}
	}
}
