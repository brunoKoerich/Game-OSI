using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	public string titulo;
	public string descricao;

	private void OnTriggerEnter (Collider col) {
		this.ChecarColisaoJogador (col);
	}

	private void ChecarColisaoJogador(Collider col) {
		if (col.gameObject.tag != "Player") {
			return;
		}

		Jogador player = col.gameObject.GetComponent<Jogador> ();
		player.itens.Add (this);

		this.gameObject.SetActive (false);
	}
}
