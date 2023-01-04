using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {
	public int lifetime=3;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag=="Police"){
			lifetime--;
			print("Hey you lose a lifetime, and have " + lifetime + " lifetime");
		}
		if(lifetime==0){
			Time.timeScale = 0;
		}
	}
}
