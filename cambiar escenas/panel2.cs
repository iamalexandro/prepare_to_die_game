using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class panel2 : MonoBehaviour {

	public string nombreEscena = "panel2";

	// Use this for initialization
	void Start () {
		SceneManager.LoadScene (nombreEscena);
	}

	// Update is called once per frame
	void Update () {

	}
}
