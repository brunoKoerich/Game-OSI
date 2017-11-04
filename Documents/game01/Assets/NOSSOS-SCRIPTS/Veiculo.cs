using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
	RequireComponent(typeof(BoxCollider)),
	RequireComponent(typeof(Rigidbody)),
	RequireComponent(typeof(SimpleCarController))
]
public class Veiculo : MonoBehaviour {
	
	[SerializeField] private Camera cameraVeiculo;

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
		this.ChecarEntrarSair();
	}
	
	private void ChecarEntrarSair () {
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
		// Cancela caso jogador esteja dentro ou longe do veiculo
		if (!this.jogadorPerto || this.jogadorDentro) {
			return;
		}

		this.jogadorDentro = true;

		// Ativa camera do jogador
		this.cameraVeiculo.gameObject.SetActive (true);

		// Ativa comandos do veiculo e fisica
		this.carroControle.enabled = true;

		Rigidbody rb = this.GetComponent<Rigidbody> ();
		rb.isKinematic = false;

		// Desativa jogador e coloca "dentro" do veiculo
		this.jogador.SetActive (false);
		this.jogador.transform.SetParent (this.transform);
	}

	private void Sair () {
		// Cancela caso jogador esteja fora do veiculo
		if (!this.jogadorDentro) {
			return;
		}

		Rigidbody rb = this.GetComponent<Rigidbody> ();

		// Cancela caso esteja andando rápido
		if (rb.velocity.magnitude > 1) {
			return;
		}

		this.jogadorDentro = false;

		// Desativa comando do veiculo e arruma sua posição
		this.carroControle.enabled = false;
		this.carroControle.transform.rotation = Quaternion.Euler(0, this.carroControle.transform.eulerAngles.y, 0);

		// Para o veiculo
		rb.isKinematic = true;

		// Ativa jogador, arruma sua posição e tira de "dentro" do veiculo
		this.jogador.transform.SetParent (null);
		this.jogador.transform.rotation = Quaternion.Euler(0, this.jogador.transform.eulerAngles.y, 0);
		this.jogador.SetActive (true);

		// Desabilita camera do veiculo
		this.cameraVeiculo.gameObject.SetActive (false);
	}

	public bool JogadorEstaDentro() {
		return this.jogadorDentro;
	}
}
