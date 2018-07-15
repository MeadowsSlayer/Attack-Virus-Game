using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CursorScr : MonoBehaviour {

	public int alltime;
	public int A;
	public int B;
	public int endScore;

	public GameObject back;
	public GameObject wiiin;
	public GameObject Barier;
	public GameObject Waver;
	public Text WIN;
	public GameObject LOSE;
	public GameObject Spawn;
	public GameObject noneobj;
	public GameObject barier1;
	public GameObject bullet;
	public GameObject bulletr;
	public GameObject bulletl;
	public bool istime = false;
	public int shoottype = 1;
	public int shoottime = 1;
	public float speed = 2f;
	public int time = 10;
	public int maxTime;
	public int score = 0;

	private Barier bar;
	private Spawner spawn;
	private Rigidbody2D myBody;

	void Start () {
		bar = Barier.GetComponent<Barier> ();
		spawn = Spawn.GetComponent<Spawner> ();
		myBody = GetComponent<Rigidbody2D> ();
	}
	

	void FixedUpdate () {
		alltime++;
		if (score >= 20 && spawn.Wave == 1) {
			spawn.Wave = 2;
		}
		if (score >= 70 && spawn.Wave == 2) {
			spawn.Wave = 3;
		}
		if (score >= 240 && spawn.Wave == 3) {
			spawn.Wave = 4;
		}
		if (score >= 300 && spawn.Wave == 4) {
			spawn.Wave = 5;
		}
		if (score == 500 && spawn.Wave == 5) {
			Destroy (LOSE);
			Waver.SetActive (false);
			A = 19000 / bar.health;
			B = alltime / bar.health*3;
			endScore = A - B;
			wiiin.SetActive (true);
			back.SetActive (true);
			WIN.text = endScore.ToString() + "score";
		}
		float moveVertical = Input.GetAxis ("Vertical") * speed;
		float moveHorizontal = Input.GetAxis ("Horizontal") * speed;

		Vector3 move = new Vector3(moveHorizontal, moveVertical, 0);
		myBody.velocity = move * speed;

		time++;
		if (time >= maxTime && Input.GetKey (KeyCode.Space) && shoottype==1) {
			Instantiate (bullet, new Vector3 (transform.position.x, transform.position.y + 0.5f, -2), Quaternion.identity);
			time = 0;
		}
		if (time >= maxTime && Input.GetKey (KeyCode.Space) && shoottype==2) {
			Instantiate (bullet, new Vector3 (transform.position.x-0.25f, transform.position.y + 0.5f, -2), Quaternion.identity);
			Instantiate (bullet, new Vector3 (transform.position.x+0.25f, transform.position.y + 0.5f, -2), Quaternion.identity);
			time = 0;
		}
		if (time >= maxTime && Input.GetKey (KeyCode.Space) && shoottype==3) {
			Instantiate (bulletl, new Vector3 (transform.position.x-0.5f, transform.position.y + 0.25f, -2), Quaternion.identity);
			Instantiate (bullet, new Vector3 (transform.position.x, transform.position.y + 0.5f, -2), Quaternion.identity);
			Instantiate (bulletr, new Vector3 (transform.position.x+0.5f, transform.position.y + 0.25f, -2), Quaternion.identity);
			time = 0;
		}
		if (shoottime == 4) {
			maxTime = 5;
		} else {
			maxTime = 15;
		}
		if (time >= maxTime && Input.GetKey (KeyCode.Space) && shoottype==5) {
			Instantiate (bulletl, new Vector3 (transform.position.x-1f, transform.position.y + 0.25f, -2), Quaternion.identity);
			Instantiate (bulletl, new Vector3 (transform.position.x-0.5f, transform.position.y + 0.25f, -2), Quaternion.identity);
			Instantiate (bulletl, new Vector3 (transform.position.x-0.45f, transform.position.y + 0.25f, -2), Quaternion.identity);
			Instantiate (bullet, new Vector3 (transform.position.x, transform.position.y + 0.5f, -2), Quaternion.identity);
			Instantiate (bulletr, new Vector3 (transform.position.x+0.45f, transform.position.y + 0.25f, -2), Quaternion.identity);
			Instantiate (bulletr, new Vector3 (transform.position.x+0.5f, transform.position.y + 0.25f, -2), Quaternion.identity);
			Instantiate (bulletr, new Vector3 (transform.position.x+1f, transform.position.y + 0.25f, -2), Quaternion.identity);
			time = 0;
		}
	}
	private void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "SpeedBaff"){
			Destroy (collider.gameObject);
			istime = true;
			StartCoroutine (TIME ());
		}
		if (collider.tag == "Antivirus banner"){
			Destroy (collider.gameObject);
			Instantiate (barier1, new Vector3 (0, -8.25f, 0), Quaternion.identity);
		}
		if (collider.tag == "TwinShot"){
			Destroy (collider.gameObject);
			shoottype = 2;
			StartCoroutine (TIMESHOT ());
		}
		if (collider.tag == "TripleShot"){
			Destroy (collider.gameObject);
			shoottype = 3;
			StartCoroutine (TIMESHOT ());
		}
		if (collider.tag == "MultiShot"){
			Destroy (collider.gameObject);
			shoottime = 4;
			StartCoroutine (TIMESHO ());
		}
		if (collider.tag == "MultiM"){
			Destroy (collider.gameObject);
			shoottype = 5;
			StartCoroutine (TIMESHOT ());
		}
		if (collider.tag == "AD"){
			Destroy (collider.gameObject);
			Instantiate (noneobj, new Vector3 (-12, 4, -2), Quaternion.identity);
			Instantiate (noneobj, new Vector3 (12, 1, -2), Quaternion.identity);
			Instantiate (noneobj, new Vector3 (-7, 6, -2), Quaternion.identity);
			Instantiate (noneobj, new Vector3 (2, 0, -2), Quaternion.identity);
			Instantiate (noneobj, new Vector3 (14, 7, -2), Quaternion.identity);
			Instantiate (noneobj, new Vector3 (3, 8, -2), Quaternion.identity);
			Instantiate (noneobj, new Vector3 (-4, 1, -2), Quaternion.identity);
			Instantiate (noneobj, new Vector3 (6, 9, -2), Quaternion.identity);
		}
	}

	IEnumerator TIME(){
		yield return new WaitForSeconds (5f);
		istime = false;
	}
	IEnumerator TIMESHOT(){
		yield return new WaitForSeconds (10f);
		shoottype = 1;
		shoottime = 1;
	}
	IEnumerator TIMESHO(){
		yield return new WaitForSeconds (10f);
		shoottime = 1;
	}
}
