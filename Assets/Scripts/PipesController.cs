using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesController : MonoBehaviour {

	public GameObject leftSide;
	public GameObject rightSide;
	public float speed =0.1f;
	int direction =1;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 position = transform.position;
		position.x += direction * speed;
		transform.position = position;

		if(direction == 1 && position.x >rightSide.transform.position.x){
			direction = -1;
		}
		if(direction == -1 && position.x <leftSide.transform.position.x){
			direction = 1;
		}
		
	}
}
