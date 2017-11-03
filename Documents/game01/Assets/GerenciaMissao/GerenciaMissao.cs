using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciaMissao : MonoBehaviour {

	public List <Missao> missoes = new List <Missao> ();
	public MissaoComObjetivosGUI missaoComObjetivosGUI;

	private Missao missaoAtual;

	private void Start() {
		this.AtualizarGUI ();
	}

	public void IniciaMissoes() {
		if (this.missaoAtual == null) {
			this.AvancarMissao ();
		}
	}

	// Ativa próxima missão disponível
	public void AvancarMissao() {
		if (this.missoes.Count == 0) {
			Debug.Log ("Nenhuma missão disponível");
			return;
		}

		this.missaoAtual = null;
		for (int i = 0; i < this.missoes.Count; i++) {
			if (this.missoes [i].GetStatus() == MissaoStatus.DISPONIVEL) {
				this.missaoAtual = this.missoes [i];
				break;
			}
		}

		if (this.missaoAtual == null) {
			Debug.Log ("Todas missões finalizadas");
		} else {
			this.missaoAtual.Ativar ();
		}

		this.AtualizarGUI ();
	}

	// Atualiza dados visuais caso existente
	public void AtualizarGUI() {
		if (this.missaoComObjetivosGUI == null) {
			return;
		}

		if (this.missaoAtual != null) {
			Debug.Log ("Objetivos: "+ this.missaoAtual.objetivos.Count);
		}

		this.missaoComObjetivosGUI.SetMissao (this.missaoAtual);
	}

}
