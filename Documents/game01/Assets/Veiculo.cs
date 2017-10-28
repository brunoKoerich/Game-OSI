using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
	RequireComponent(typeof(BoxCollider)),
	RequireComponent(typeof(Rigidbody)),
	RequireComponent(typeof(SimpleCarController))
]
public class Veiculo : MonoBehaviour {
	
	public Camera camera;

	private bool jogadorDentro = false;
	private bool jogadorPerto = false;

	private SimpleCarController carroControle;
	private GameObject jogador;

	private void Start () {
		this.carroControle = GetComponent<SimpleCarController> ();
		this.carroControle.enabled = false;

		if (this.camera == null) {
			Debug.LogError ("Veiculo sem camera");
		}

		this.camera.gameObject.SetActive (false);

	}

	private void Update () {
		if (Input.GetButtonUp("Jump")) {
			if (this.jogadorDentro) {
				Debug.Log ("Sair");
				this.Sair ();
			} else {
				Debug.Log ("Entrar");
				this.Entrar ();
			}
		}
	}

	private void OnTriggerEnter (Collider col) {
		this.ChecarJogadorPerto (col);
	}

	private void OnTriggerExit (Collider col) {
		this.ChecarJogadorLonge (col);
	}

	private void ChecarJogadorPerto(Collider col) {
		if (col.gameObject.tag == "Player") {
			this.jogador = col.gameObject;
			this.jogadorPerto = true;
		}
	}

	private void ChecarJogadorLonge(Collider col) {
		if (col.gameObject.tag == "Player") {
			this.jogador = null;
			this.jogadorPerto = false;
		}
	}

	private void Entrar () {
		if (this.jogadorPerto && !this.jogadorDentro) {
			this.jogadorDentro = true;

			this.camera.gameObject.SetActive (true);

			this.carroControle.enabled = true;

			this.jogador.SetActive (false);
			this.jogador.transform.SetParent (this.transform);
		}
	}

	private void Sair () {
		if (this.jogadorDentro) {
			this.jogadorDentro = false;

			this.carroControle.enabled = false;

			this.jogador.transform.SetParent (null);
			this.jogador.SetActive (true);

			this.camera.gameObject.SetActive (false);
		}
	}
}
