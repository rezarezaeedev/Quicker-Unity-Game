using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCreator : MonoBehaviour {
	public GameObject PoliceObject;
 

	[Header("Scale")]
	private float scale;
	public float ScaleMin=0.3f;
	public float ScaleMax=0.5f;

	[Header("Location X")]
	private float xPositionStart=-2f;
	private float xPositionEnd=2f;
	public float xPosition;

	[Header("Location Y")]
	private float yPositionStart=5f;
	private float yPositionEnd=4f;
	public float yPosition;

	[Header("Time Creating")]
	public float BetweenEachCreate=1f;
	private float LastCreation=0f;
	private short CreationLimit=7;

	// Use this for initialization
	void Start () {
		xPosition=Random.Range(xPositionStart, xPositionEnd);
		yPosition=Random.Range(yPositionStart, yPositionEnd);
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > LastCreation + BetweenEachCreate){
			scale = Random.Range(ScaleMin, ScaleMax);
			GameObject newObject = Instantiate(PoliceObject, new Vector3(xPosition, yPosition, 0), Quaternion.identity);
			newObject.transform.localScale = new Vector3(scale, scale, scale);
			xPosition=Random.Range(xPositionStart, xPositionEnd);
			yPosition=Random.Range(yPositionStart, yPositionEnd);
			LastCreation=Time.time ;
		}
	}

}