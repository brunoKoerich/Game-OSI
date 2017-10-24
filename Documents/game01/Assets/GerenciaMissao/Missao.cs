using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Missao : MonoBehaviour {
	
	public string titulo;
	public string descricao;

	private MissaoStatus status = MissaoStatus.DISPONIVEL;
	private List<MissaoObjetivo> objetivos = new List<MissaoObjetivo>();

	public List<MissaoObjetivo> GetObjetivos () {
		return this.objetivos;
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
		for (int i = 0; i < this.GetObjetivos().Count; i++) {
			if (!this.GetObjetivos()[i].completo) {
				return false;
			}
		}

		return this.Completar ();
	}

}