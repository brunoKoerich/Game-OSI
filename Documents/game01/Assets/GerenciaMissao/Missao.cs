using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missao : MonoBehaviour {
	
	[SerializeField] private string titulo;
	[SerializeField] private string descricao;
	[SerializeField] private List<MissaoObjetivo> objetivos;
	[SerializeField] private List<GameObject> objetosAtivosAoCompletar;
	[SerializeField] private List<GameObject> objetosInativosAoCompletar;

	private MissaoStatus status = MissaoStatus.DISPONIVEL;

	private void Start() {
		// Vincula objetivos à missão
		for (int i = 0; i < this.objetivos.Count; i++) {
			this.objetivos [i].SetMissao (this);
		}
	}

	public string GetTitulo() {
		return this.titulo;
	}

	public string GetDescricao() {
		return this.descricao;
	}

	public List<MissaoObjetivo> GetObjetivos() {
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
			if (!this.objetivos[i].GetCompleto()) {
				return false;
			}
		}

		return this.Completar ();
	}

}