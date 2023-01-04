using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {
	public int lifetime=3;
	public GameObject cylinder;
	public GameObject boom;
	public Transform car;
	public Color default_color;
	public float active_red_color;
	public float pause_time=0f;
	public bool pause_time_flag=false;
	


	void Start () {
		default_color=cylinder.GetComponent<Renderer>().material.color;print(default_color);
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > active_red_color){
			cylinder.GetComponent<Renderer>().material.color = default_color;
		}
		if(Time.time > pause_time && pause_time_flag){
			cylinder.GetComponent<Renderer>().material.color = new Color(1 ,0 ,0);
			Time.timeScale = 0;
		}
	
	}

	void OnTriggerEnter2D(Collider2D col){	
		if(col.tag=="Police"){
			lifetime--;
			active_red_color=Time.time+2f;
			cylinder.GetComponent<Renderer>().material.color = new Color(0.9f ,0.8f ,0.8f);
			col.GetComponent<Renderer>().material.color = new Color(1 ,0 ,0);
			Destroy(col.gameObject, 0.5f);
			print("Hey you lose a lifetime, and have " + lifetime + " lifetime");
		}
		
		if(lifetime==0){
			GameObject newboom = Instantiate(boom, car.position, Quaternion.identity);
			pause_time=Time.time+1.8f;
			pause_time_flag=true;
			Destroy(gameObject, 2f);
		}
	}
}
