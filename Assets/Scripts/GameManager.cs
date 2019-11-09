using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public GameObject FinishPanel;
	public GameObject GOUI;
	float time;
	int attemp, score;
	public Text TimeUI,ScoreUI, AttempUI;
	// Use this for initialization
	void Start () {
		instance = this;
		Time.timeScale = 1;
		attemp = 3;
		time = 120f;
		score = 0;


		TimeUI = GameObject.Find ("Timer").GetComponent<Text>();
		ScoreUI = GameObject.Find ("Score").GetComponent<Text>();
		AttempUI = GameObject.Find ("Nyawa").GetComponent<Text>();

		GOUI.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (time > 0) {
			time -= Time.deltaTime;
		}


		TimeUI.text = "" + (int)time;
		ScoreUI.text = "" + score;
		AttempUI.text = "X " + attemp;

		if (attemp == 0 || time <= 0f) {
			showGameOver ();
		}
	}

	public void useAttemp () {
		if (attemp>0)
		attemp -= 1;
	}

	public void AddScore () {
		score += 100;
	}


	public void ShowFinishUI () {
		FinishPanel.SetActive (true);
		Time.timeScale = 0;
	}

	public void showGameOver () {
		Canvas_S.instance.ShowGameOverUI ();
		Time.timeScale = 0;		
	}

	public void GoToLevel (string LevelName) {
		SceneManager.LoadScene (LevelName);
	}


}
