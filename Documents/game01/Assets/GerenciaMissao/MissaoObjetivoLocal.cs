using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissaoObjetivoLocal : MissaoObjetivo {

	private void OnTriggerEnter (Collider col) {
		this.ChecarJogadorChegou (col);
	}

	private void ChecarJogadorChegou(Collider col) {
		// Completa objetivo caso jogador entrar na área do objeto
		if (col.gameObject.tag == "Player") {
			this.Completar();
		}
	}
}
