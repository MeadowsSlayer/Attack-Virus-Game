using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AD : MonoBehaviour {

	public int time;
	public int max;

	void Start () {
		max = Random.Range (30, 240);
	}

	void Update () {
		time++;
		if (time >= max) {
			StartCoroutine (TIME ());
		}
	}

	IEnumerator TIME(){
		this.gameObject.SetActive (true);
		yield return new WaitForSeconds (3f);
		Destroy (this.gameObject);
	}
}
