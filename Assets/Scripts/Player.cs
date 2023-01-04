using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public Transform transform;
	public Transform BulletCreationPositionTransform;
	public Transform BulletObject;
	public float speed=2.5f;
	public float nitro=0f;
	public float activeNitro;
	public float deActiveNitro;



	private double nextFire = 0.0f;

	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform>();
		nextFire =0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > deActiveNitro && Input.GetKeyDown(KeyCode.LeftShift))
        {	
            nitro=3f;
			activeNitro=Time.time+4;
			deActiveNitro=Time.time+10;
        }

		if (Time.time > activeNitro )
        {	
            nitro=0f;
        }

		if(Input.GetKey(KeyCode.UpArrow) && transform.position.y < 5)
		{	 
			transform.position += Vector3.up * Time.deltaTime * (speed + nitro);  
		} 

		if(Input.GetKey(KeyCode.DownArrow) && transform.position.y > -1f)
		{ 
			transform.position += Vector3.down * Time.deltaTime * (speed + nitro);  
		}

		if(Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -3.2f)
		{ 
			transform.position += Vector3.left * Time.deltaTime * (speed + nitro);  
		}

		if(Input.GetKey(KeyCode.RightArrow) && transform.position.x < 0.4f)
		{ 
			transform.position += Vector3.right * Time.deltaTime * (speed + nitro);  
		}

		if(Input.GetKey(KeyCode.Space) && Time.time > nextFire )
		{    
		 	Instantiate(BulletObject, BulletCreationPositionTransform.position, Quaternion.identity);
			nextFire= Time.time + 0.35;
		}
	}
} 