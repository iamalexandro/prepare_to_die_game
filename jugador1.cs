using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class jugador1 : MonoBehaviour {

	public float time = 160.0f;
	public float velocidad = 10;
	public Text textMonedas;
	public Text textVictoria;
	public Text textVidas;
	public Text textOver;
	public Text textTime;
	public Button reiniciar;
	public string nombreEscena = "panel2";

	int monedas=0;
	int vidas=3;
	bool haSalido;


	Rigidbody miRigidBody;
	Vector3 posicionInicial;

	// Use this for initialization
	void Start () {
		
		miRigidBody = GetComponent<Rigidbody>();
		posicionInicial = transform.position;
		textVictoria.enabled = false;
		textOver.enabled = false;
		//reiniciar.enabled = true;
		haSalido = false;

	}
	// Update is called once per frame
	void FixedUpdate () {

		if (!haSalido) {
			//Captura de teclas arriba abajo y a los lados.
			float vertical = Input.GetAxis ("Vertical");
			float horizontal = Input.GetAxis ("Horizontal");

			//Movimiento del jugador
			miRigidBody.AddForce (new Vector3 (horizontal, 0, vertical) * velocidad);

			//timepo
			if (time < 0) {
				velocidad = 0;
				textOver.enabled = true;
				time = 0; 
				textVidas.text = "0";
			}

			if (vidas == 0) {
				time = 0;
			}

			time -=Time.fixedDeltaTime;
			textTime.text = time.ToString("f0") + "" ;

		}
	}

	//COLISIONES

	void OnTriggerEnter(Collider otro){
		//Si colisiona con la Salida
		if (otro.CompareTag ("salida")) {

			//Ha salido
			haSalido = true;

			//Activamos el texto de la victoria 
			textVictoria.enabled = false;

			//Cambiar el texto victoria añadiendo el numero de monedas
			textVictoria.text = "Felicidades has pasado al nivel 2\n " + "recogiste " + monedas + " monedas ";	

			//Cargar la siguiente escena
			SceneManager.LoadScene (nombreEscena);

			//Velocidad a 0
			miRigidBody.angularVelocity = Vector3.zero;

			//Verifica si el tiempo de juego merece bonificacion de Vida.
			if (time >= 80) {
				vidas = vidas + 1;
				textVidas.text = "" + vidas;
			}

			//Si colisiona con una Mina (enemigo)
		} else if (otro.CompareTag ("Nicola")) {
			//Reposiciona al inicio el jugador al colisionar
			miRigidBody.MovePosition (posicionInicial);
			//Hace su velocidad = 0
			miRigidBody.velocity = Vector3.zero;
			miRigidBody.angularVelocity = Vector3.zero;
			//Tendra 0 monedas
			monedas = 0;
			textMonedas.text = "" + monedas;
			//Le resta una vida al jugador 
			vidas = vidas - 1;
			//Evalua el numero de vidas para el GAME OVER
			if (vidas == 0) {
				textVidas.text = "0";
				velocidad = 0;
				textOver.enabled = true;
			}
			textVidas.text = "" + vidas;

			//Si colisiona con una Moneda
		} else if (otro.CompareTag ("moneda")) {
			otro.gameObject.SetActive (false);
			monedas = monedas + 1;
			textMonedas.text = "" + monedas;


			//Si colisiona con el vacio (se cae)
		} else if (otro.CompareTag ("vacio")) {
			
			miRigidBody.MovePosition (posicionInicial);
			miRigidBody.velocity = Vector3.zero;
			miRigidBody.angularVelocity = Vector3.zero;
			monedas = 0;
			textMonedas.text = "" + monedas;
			vidas = vidas - 1;

			if (vidas == 0) {
				textVidas.text = "0";
				velocidad = 0;
				textOver.enabled = true;
				
			}
			textVidas.text = "" + vidas;

		} else if (otro.CompareTag ("vida")) {
			otro.gameObject.SetActive (false);
			vidas = vidas + 1;
			textVidas.text = "" + vidas;
		}
	

	}




}
