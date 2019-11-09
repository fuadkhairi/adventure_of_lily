using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	//variables declared
	public Rigidbody2D rb2d;
	Animator anim;
	float playerSpeed = 2.0f;
	float playerJump = 250f;
	public float groundRadius=.2f;
	public LayerMask Ground;

	public AudioSource jump_fx, coin;

	bool isGrounded;
	int jump;
	//AudioSource jump;
	GameObject startPos;
	// Use this for initialization
	void Start () {
		startPos = GameObject.FindGameObjectWithTag ("Start");
		gameObject.transform.position = startPos.transform.position;
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		jump = 2;
		//jump = GetComponent<AudioSource> ();
		//Camera = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		float move = Input.GetAxis ("Horizontal");
		//X axes of movement
		if (Input.GetKey (KeyCode.LeftArrow)) {
			rb2d.velocity = new Vector2 (move * playerSpeed, rb2d.velocity.y);
			anim.SetBool ("moveleft", true);
			transform.localScale = new Vector2 (-1, 1);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			rb2d.velocity = new Vector2 (move * playerSpeed, rb2d.velocity.y);
			anim.SetBool ("moveright", true);
			transform.localScale = new Vector2 (1, 1);
		} else {

			anim.SetBool ("moveleft", false);
			anim.SetBool ("moveright", false);

		}
		float velocity_y = rb2d.velocity.y;


		if (Input.GetKeyDown (KeyCode.Space)) {
			MakeAJump ();
		}
		if (velocity_y > 5) {
			velocity_y = 5;
		}
	}

	void OnBecameInvisible () {
		//gameObject.transform.position = startPos.transform.position;
	}

	void MakeAJump () {
		//if not 0, jump and decrease jump var
		if (jump>0){
			rb2d.AddForce (new Vector2 (0, playerJump));
			isGrounded = false;
			jump -= 1;
			jump_fx.Play ();
		}
		// if 0 dont jump
		if (jump == 0) {
			return;
		}
	}
	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Start") {
			Debug.Log ("You touch start");
		}
		if (col.tag == "Finish") {
			Debug.Log ("You touch finish");
			GameManager.instance.ShowFinishUI ();
		}


		if (col.tag == "Ranjau") {
			gameObject.transform.position = startPos.transform.position;
			GameManager.instance.useAttemp ();
		}

		if (col.tag == "Coin") {
			GameManager.instance.AddScore ();
			coin.Play ();
			Destroy (col.gameObject);
		}

		if (col.tag == "Water") {
			rb2d.gravityScale = -0.25f;
		}
			
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.tag == "Water") {
			rb2d.gravityScale = 1.25f;
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Ground") {
			jump = 2;
			isGrounded = true;
		}

		if (col.gameObject.tag == "pipes") {
			transform.parent = col.gameObject.transform;
		}
	}

	void OnCollisionExit2D (Collision2D col) {
		if (col.gameObject.tag == "pipes") {
			transform.parent = null;
		}
	}


}
