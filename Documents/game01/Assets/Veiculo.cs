using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
	RequireComponent(typeof(BoxCollider)),
	RequireComponent(typeof(Rigidbody)),
	RequireComponent(typeof(SimpleCarController))
]
public class Veiculo : MonoBehaviour {
	
	public Camera cameraVeiculo;

	private bool jogadorDentro = false;
	private bool jogadorPerto = false;

	private SimpleCarController carroControle;
	private GameObject jogador;

	private void Start () {
		this.carroControle = GetComponent<SimpleCarController> ();
		this.carroControle.enabled = false;

		if (this.cameraVeiculo == null) {
			Debug.LogError ("Veiculo sem camera");
		}

		this.cameraVeiculo.gameObject.SetActive (false);

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

			this.cameraVeiculo.gameObject.SetActive (true);

			this.carroControle.enabled = true;

			this.jogador.SetActive (false);
			this.jogador.transform.SetParent (this.transform);
		}
	}

	private void Sair () {
		if (this.jogadorDentro) {
			this.jogadorDentro = false;

			this.carroControle.enabled = false;
			this.carroControle.transform.rotation = Quaternion.Euler(0, this.carroControle.transform.eulerAngles.y, 0);

			this.jogador.transform.SetParent (null);
			this.jogador.transform.rotation = Quaternion.Euler(0, this.jogador.transform.eulerAngles.y, 0);
			this.jogador.SetActive (true);

			this.cameraVeiculo.gameObject.SetActive (false);
		}
	}
}
