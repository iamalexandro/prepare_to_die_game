using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampa2 : MonoBehaviour {

	public Vector3 inicial;
	public Vector3 final;
	Vector3 posicion;
	public bool activa;
	public float tiempo_max;
	private float tiempo_actual;
	public float delay;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (activa) {
			if (delay < 0) {
				if (tiempo_actual < tiempo_max) {
					this.transform.position = Vector3.Lerp (inicial, final, tiempo_actual / tiempo_max);
					this.transform.Rotate (0,0,180*Time.deltaTime);
					tiempo_actual += Time.deltaTime;
				}
			} else {
				delay -= Time.deltaTime;
			}

		}
	}

	void OnCollisionEnter(Collision otro){
		//Si colisiona con la trampa
		if (otro.gameObject.CompareTag ("Player")) {
			activa = true;
		}
	}


}
