using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotador : MonoBehaviour {

	public float velocidad = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () { 
		transform.Rotate(0,0,velocidad * Time.deltaTime);
	}
}
