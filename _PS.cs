using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PS : MonoBehaviour {

	void FixedUpdate () 
	{
		Destroy(this.gameObject, 1f);
	}
}
