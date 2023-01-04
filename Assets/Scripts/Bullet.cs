using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public Transform transform;
	public float speed=8f;
	
	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform>(); 	 
	}
	
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.up * Time.deltaTime * speed;

		if(transform.position.y>8.6)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		
		if(col.tag=="Wheel"){
			Destroy(gameObject);
		}
	}
}