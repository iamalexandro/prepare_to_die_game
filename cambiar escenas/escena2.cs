using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escena2 : MonoBehaviour {

	public string nombreEscena = "escena2";

	// Use this for initialization
	void Start () {
		//SceneManager.LoadScene (nombreEscena);
	}

	// Update is called once per frame
	void Update () {

	}

	public void cambiarEscena (){
		SceneManager.LoadScene (nombreEscena);
	}
}
