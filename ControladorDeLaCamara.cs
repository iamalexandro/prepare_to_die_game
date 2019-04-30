using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeLaCamara : MonoBehaviour {

	public GameObject jugador;
	Vector3 distancia;

	// Use this for initialization
	void Start () {
		distancia = transform.position - jugador.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
			transform.position = jugador.transform.position + distancia;
	}
}
