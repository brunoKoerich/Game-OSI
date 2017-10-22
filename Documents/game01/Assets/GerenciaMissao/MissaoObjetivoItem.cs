using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissaoObjetivoItem : MissaoObjetivo {

	public string itemTitulo;
	public int itemQuantidade;

	private void Update () {
		this.ChecarItensJogador ();
	}

	private void ChecarItensJogador() {
		Jogador jogador = GameObject.FindObjectOfType<Jogador> ();

		int quantidadeAtual = 0;
		for (int i = 0; i < jogador.itens.Count; i++) {
			if (jogador.itens [i].titulo == this.itemTitulo) {
				quantidadeAtual++;
			}
		}

		if (quantidadeAtual >= this.itemQuantidade) {
			this.Completar ();
		}
	}
}
