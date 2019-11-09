using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public GameObject Canva;
	public float timer;
	public string GoToLevel;
	// Use this for initialization
	void Start () {
		StartCoroutine (ShowUI());
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	public void GoTo () {
		SceneManager.LoadScene (GoToLevel);
	}

	IEnumerator ShowUI () {
		yield return new WaitForSeconds (timer);
		Canva.SetActive (true);
	}
}
