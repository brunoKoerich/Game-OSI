﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Missao : MonoBehaviour {
	
	public string titulo;
	public string descricao;
	public List<MissaoObjetivo> objetivos;
	public List<GameObject> objetosAtivosAoCompletar;
	public List<GameObject> objetosInativosAoCompletar;

	private MissaoStatus status = MissaoStatus.DISPONIVEL;

	private void Start() {
		// Vincula objetivos à missão
		for (int i = 0; i < this.objetivos.Count; i++) {
			this.objetivos [i].setMissao (this);
		}
	}

	public MissaoStatus GetStatus() {
		return this.status;
	}

	public bool Ativar() {
		if (this.status == MissaoStatus.DISPONIVEL) {
			Debug.Log ("Missão \"" + this.titulo + "\" ativa");

			this.status = MissaoStatus.ATIVA;
			return true;
		}

		Debug.Log ("Missão \"" + this.titulo + "\" não disponível");
		return false;
	}


	private bool Completar() {
		if (this.status == MissaoStatus.ATIVA) {
			Debug.Log ("Missão \"" + this.titulo + "\" completada");

			this.status = MissaoStatus.COMPLETADA;

			// Ativa objetos necessários
			for (int i = 0; i < this.objetosAtivosAoCompletar.Count; i++) {
				this.objetosAtivosAoCompletar [i].SetActive (true);
			}

			// Inativa objetos necessários
			for (int i = 0; i < this.objetosInativosAoCompletar.Count; i++) {
				this.objetosInativosAoCompletar [i].SetActive (false);
			}

			GerenciaMissao gerenciaMissao = GameObject.FindObjectOfType<GerenciaMissao> ();
			if (gerenciaMissao != null) {
				gerenciaMissao.AvancarMissao ();
			}
			return true;
		}

		Debug.Log ("Missão \"" + this.titulo + "\" não ativa");
		return false;
	}

	public bool ChecarObjetivosCompletos() {
		// Verifica se algum objetivo não foi concluido
		for (int i = 0; i < this.objetivos.Count; i++) {
			if (!this.objetivos[i].completo) {
				return false;
			}
		}

		return this.Completar ();
	}

}