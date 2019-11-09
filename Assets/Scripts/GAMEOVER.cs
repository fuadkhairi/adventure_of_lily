using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GAMEOVER : MonoBehaviour {
	public string SceneNameX;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Y)) {
			SceneManager.LoadScene (SceneNameX);
		}

		if (Input.GetKey (KeyCode.N)) {
			SceneManager.LoadScene ("MainMenu");
		}
	}
}
