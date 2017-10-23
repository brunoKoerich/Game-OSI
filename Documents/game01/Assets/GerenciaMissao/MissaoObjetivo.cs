using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissaoObjetivo: MonoBehaviour {

	public string titulo;
	public Missao missao;
	public bool completo = false;

	// Executa após a inicialização do objeto
	private void Awake() {
		this.AdicionarNaMissao ();
	}

	private void AdicionarNaMissao() {
		if (this.missao == null) {
			Debug.Log ("Objetivo \"" + this.titulo + "\" sem missão");
		}

		// Adiciona objetivo à missão
		this.missao.GetObjetivos ().Add (this);
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
