using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissaoObjetivoItem : MissaoObjetivo {

	[SerializeField] private string itemTitulo;
	[SerializeField] private int itemQuantidade;

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
		List<Item> itens = this.inventario.GetItens();
		for (int i = 0; i < itens.Count; i++) {
			if (itens[i].GetTitulo() == this.itemTitulo) {
				quantidadeAtual++;
			}
		}

		if (quantidadeAtual >= this.itemQuantidade) {
			this.Completar ();
		}
	}
}
