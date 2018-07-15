using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoneObj : MonoBehaviour {

	private SpriteRenderer sprite;
	public Sprite AD1;
	public Sprite AD2;
	public Sprite AD3;
	public Sprite AD4;
	public int id;
	public int time;
	public int max;
	public int change;

	void Start () {
		sprite = GetComponent<SpriteRenderer> ();
		max = Random.Range (30, 240);
	}

	void Update () {
		change++;
		if (change >= 60) {
			id = Random.Range (1, 4);
			change = 0;
		}
		time++;
		if (time >= max) {
			StartCoroutine (TIME ());
		}
		if (id == 1) {
			sprite.sprite = AD1;
		}
		if (id == 2) {
			sprite.sprite = AD2;
		}
		if (id == 3) {
			sprite.sprite = AD3;
		}
		if (id == 4) {
			sprite.sprite = AD4;
		}
	}

	IEnumerator TIME(){
		this.gameObject.SetActive (true);
		yield return new WaitForSeconds (3f);
		Destroy (this.gameObject);
	}
}
