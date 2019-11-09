﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teddy : MonoBehaviour {
	Rigidbody2D rb2d;
	bool turnRight;
	// Use this for initialization
	void Start () {
		turnRight = false;
		rb2d = GetComponent<Rigidbody2D> ();
		StartCoroutine (changeTurn ());
	}
	
	// Update is called once per frame
	void Update () {
		if (!turnRight) {
			transform.localScale = new Vector2 (1, 1);
			rb2d.velocity = new Vector2 (-1, rb2d.velocity.y);
		} else {

			rb2d.velocity = new Vector2 (1, rb2d.velocity.y);
			transform.localScale = new Vector2 (-1, 1);
		}
	}

	IEnumerator changeTurn () {
		yield return new WaitForSeconds (2f);
		if (turnRight) {
			turnRight = false;
		} else {
			turnRight = true;
		}
		StartCoroutine (changeTurn ());

	}
}
