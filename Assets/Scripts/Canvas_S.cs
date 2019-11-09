using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_S : MonoBehaviour {
	public static Canvas_S instance;
	public GameObject GameOverUI;
	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	public void ShowGameOverUI () {
		GameOverUI.SetActive (true);
	}
}
