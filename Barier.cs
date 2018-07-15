using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Barier : MonoBehaviour {

	public int health=50;
	public GameObject Wave;
	public GameObject Lose;

	void Update () {
		if (health <= 0) {
			Wave.SetActive (false);
			Lose.SetActive (true);
			StartCoroutine (Losed ());
		}
	}
	private void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Bug"){
			health -= 1;
		}
		if (collider.tag == "Virus" || collider.tag == "Load"){
			health -= 2;
		}
	}

	IEnumerator Losed(){
		yield return new WaitForSeconds (5);
		SceneManager.LoadScene (1);
	}
}
