using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissaoObjetivo: MonoBehaviour {

	public string titulo;
	public bool completo = false;

	protected Missao missao;

	public void setMissao(Missao missao) {
		this.missao = missao;
	}

	public void Completar() {
		if (missao.GetStatus() != MissaoStatus.ATIVA) {
			Debug.Log ("Objetivo \"" + this.titulo + "\" não disponível");
			return;
		}

		Debug.Log ("Objetivo \"" + this.titulo + "\" concluido");

		this.completo = true;

		this.missao.ChecarObjetivosCompletos ();
	}

}
