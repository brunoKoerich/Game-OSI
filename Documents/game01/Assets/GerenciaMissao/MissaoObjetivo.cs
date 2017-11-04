using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissaoObjetivo: MonoBehaviour {

	[SerializeField] public string titulo;
	[SerializeField] public List<GameObject> objetosAtivosAoCompletar;
	[SerializeField] public List<GameObject> objetosInativosAoCompletar;

	protected bool completo = false;
	protected Missao missao;

	public void SetMissao(Missao missao) {
		this.missao = missao;
	}

	public bool GetCompleto() {
		return this.completo;
	}

	protected void Completar() {
		if (this.missao == null) {
			Debug.Log ("Objetivo \"" + this.titulo + "\" sem missão");
			return;
		}

		if (missao.GetStatus() != MissaoStatus.ATIVA) {
			// Debug.Log ("Objetivo \"" + this.titulo + "\" não disponível");
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
