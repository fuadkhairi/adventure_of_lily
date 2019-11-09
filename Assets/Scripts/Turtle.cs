using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour {
	Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();	
		StartCoroutine (Jump ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Jump () {
		rb2d.AddForce (new Vector2 (0, 200f));
		yield return new WaitForSeconds (3f);
		StartCoroutine (Jump ());
	}
}
