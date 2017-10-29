using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissaoObjetivo: MonoBehaviour {

	public string titulo;
	public bool completo = false;
	public List<GameObject> objetosAtivosAoCompletar;
	public List<GameObject> objetosInativosAoCompletar;

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

		// Ativa objetos necessários
		for (int i = 0; i < this.objetosAtivosAoCompletar.Count; i++) {
			this.objetosAtivosAoCompletar [i].SetActive (true);
		}

		// Inativa objetos necessários
		for (int i = 0; i < this.objetosInativosAoCompletar.Count; i++) {
			this.objetosInativosAoCompletar [i].SetActive (false);
		}

		this.missao.ChecarObjetivosCompletos ();
	}

}
