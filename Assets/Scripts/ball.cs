using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {

	Rigidbody2D rb2d;
	bool turnRight;

	void Start () {
		turnRight = false;
		rb2d = GetComponent<Rigidbody2D> ();
		StartCoroutine (changeTurn ());
		
	}

	void Update () {
		if (!turnRight) {
			transform.localScale = new Vector2 (1, 1);
			rb2d.velocity = new Vector2 (-2, rb2d.velocity.y);
		} else {

			rb2d.velocity = new Vector2 (2, rb2d.velocity.y);
			transform.localScale = new Vector2 (-1, 1);
		}
	}

	IEnumerator changeTurn () {
		yield return new WaitForSeconds (3f);
		if (turnRight) {
			turnRight = false;
		} else {
			turnRight = true;
		}
		StartCoroutine (changeTurn ());

	}
}

