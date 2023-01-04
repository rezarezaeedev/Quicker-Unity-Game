using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour {
	public Transform transform;

	[Header("Speed")]
	public float speed;
	private float speedMin=0.5f;
	private float speedMax=3f;


	
	// Use this for initialization
	void Start () {
		speed=Random.Range(speedMin, speedMax);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.down * Time.deltaTime * speed;

		if(transform.position.y<-6)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag=="Bullet"){
			Destroy(gameObject);
		}
	}

	 

}