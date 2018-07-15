using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
	public float spin = 20;

	void FixedUpdate ()
	{
		StartCoroutine(mRotate());
	}
		
	IEnumerator mRotate()
	{
		transform.Rotate (new Vector3 (0, 0, spin));
		yield return new WaitForSeconds (5f);
	}
}
