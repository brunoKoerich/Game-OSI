using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissaoObjetivoVeiculo : MissaoObjetivo {

	public Veiculo veiculo;
	public bool jogadorDentro;

	private void Start () {
		if (this.veiculo == null) {
			Debug.Log ("Objetivo \"" + this.titulo + "\" sem veiculo");
		}
	}

	private void Update () {
		this.ChecarVeiculo ();
	}

	private void ChecarVeiculo () {
		if (this.veiculo == null) {
			return;
		}

		if (this.veiculo.JogadorEstaDentro() == this.jogadorDentro && !this.completo) {
			this.Completar ();
		}
	}
}
