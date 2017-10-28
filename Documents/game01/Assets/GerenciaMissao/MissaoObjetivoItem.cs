using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissaoObjetivoItem : MissaoObjetivo {

	public string itemTitulo;
	public int itemQuantidade;

	private Inventario inventario;

	private void Start () {
		this.inventario = GameObject.FindObjectOfType<Inventario> ();

		if (this.inventario == null) {
			Debug.Log ("Inventário não encontrado");
		}
	}

	private void Update () {
		this.ChecarItensInventario ();
	}

	private void ChecarItensInventario() {
		if (this.inventario == null) {
			return;
		}

		int quantidadeAtual = 0;
		for (int i = 0; i < this.inventario.itens.Count; i++) {
			if (this.inventario.itens [i].titulo == this.itemTitulo) {
				quantidadeAtual++;
			}
		}

		if (quantidadeAtual >= this.itemQuantidade) {
			this.Completar ();
		}
	}
}
