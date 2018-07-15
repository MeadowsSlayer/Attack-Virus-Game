using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject virus;
	public GameObject Load;
	public GameObject AD;
	public GameObject Zip;
	public GameObject Troyan;
	public GameObject Bug;

	public GameObject Time;
	public GameObject Speed;
	public GameObject Twin;
	public GameObject Triple;
	public GameObject Multi;
	public GameObject Antivirus;

	public GameObject DDOS;
	public Text Wavetext;

	public int ddostime;
	public int virustime;
	public int loadtime;
	public int ADtime;
	public int Ziptime;
	public int Troyantime;
	public int Wormtime;
	public int bafftime;
	public int baff2time;
	public int bugtime;

	public int Wave = 1;
	public int R;
	public int T;

	void Start () {
		
	}

	void Update () {
		virustime++;
		if (Wave == 2) {Wavetext.text = "Wave 2";}
		if (Wave == 3) {Wavetext.text = "Wave 3";}
		if (Wave == 4) {Wavetext.text = "Wave 4";}
		if (Wave >= 2) {
			loadtime++;
			Ziptime++;
		}
		if (Wave >= 3) {
			Troyantime++;
			Wormtime++;
			ADtime++;
		}
		if (Wave >= 4) {
			bugtime++;
		}
		if (Wave == 5) {
			Wavetext.text = "Wave 5";
			bugtime++;
		}
		bafftime++;
		baff2time++;
		if (virustime >= Random.Range (60, 120)) {
			Instantiate (virus, new Vector3 (Random.Range(-12f, 12f), 8.8f, -1), Quaternion.identity);
			virustime = 0;
		}
		if (loadtime >= Random.Range (1200, 2400) && Wave>=2) {
			Instantiate (Load, new Vector3 (Random.Range(-12f, 12f), 7.4f, -1), Quaternion.identity);
			loadtime = 0;
		}
		if (ADtime >= Random.Range (600, 1200) && Wave>=3) {
			Instantiate (AD, new Vector3 (Random.Range(-12f, 12f), 7.4f, -1), Quaternion.identity);
			ADtime = 0;
		}
		if (Ziptime >= Random.Range (480, 1200) && Wave>=2) {
			Instantiate (Zip, new Vector3 (Random.Range(-12f, 12f), 8.4f, -1), Quaternion.identity);
			Ziptime = 0;
		}
		if (Troyantime >= Random.Range (600, 1200) && Wave>=3) {
			Instantiate (Troyan, new Vector3 (16, Random.Range(3f, 6f), -1), Quaternion.identity);
			Troyantime = 0;
		}
		if (bafftime >= Random.Range (300, 600)) {
			R = Random.Range (1,4);
			if (R == 1) {
				Instantiate (Time, new Vector3 (Random.Range (-9f, 9f), 10f, -1), Quaternion.identity);
			}
			if (R == 2) {
				Instantiate (Antivirus, new Vector3 (Random.Range (-9f, 9f), 10f, -1), Quaternion.identity);
			}
			if (R == 3) {
				Instantiate (Twin, new Vector3 (Random.Range (-9f, 9f), 10f, -1), Quaternion.identity);
			}
			if (R == 4) {
				Instantiate (Triple, new Vector3 (Random.Range (-9f, 9f), 10f, -1), Quaternion.identity);
			}
			bafftime = 0;
		}
		if (baff2time >= Random.Range (120, 480)) {
			T = Random.Range (1,3);
			if (R == 1) {
				Instantiate (Multi, new Vector3 (Random.Range (-9f, 9f), 10f, -1), Quaternion.identity);
			}
			if (R == 2) {
				Instantiate (Speed, new Vector3 (Random.Range (-9f, 9f), 10f, -1), Quaternion.identity);
			}
			if (R == 3) {
				Instantiate (Antivirus, new Vector3 (Random.Range (-9f, 9f), 10f, -1), Quaternion.identity);
			}
			baff2time = 0;
		}
		if (bugtime >= Random.Range (2400, 4800) && Wave >= 4) {
			ddostime++;
			DDOS.SetActive (true);
			if (ddostime == 30) {
				DDOS.SetActive (false);
			}
			if (ddostime == 60) {
				DDOS.SetActive (true);
			}
			if (ddostime >= 90) {
				DDOS.SetActive (false);
				bugtime = 0;
				for (int c = 0; c < 80; c++) {
					Instantiate (Bug, new Vector3 (Random.Range (-9f, 9f), Random.Range (0f, 8f), -1), Quaternion.identity);
				}
				ddostime = 0;
			}
		}
	}
}
