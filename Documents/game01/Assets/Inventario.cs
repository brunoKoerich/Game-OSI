﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour {
	
	public List<Item> itens;

	public void AdicionarItem(Item item, bool unico) {
		// Retira itens antigos se só pode ter um item desse tipo no inventário
		if (unico) {
			for (int i = 0; i < this.itens.Count; i++) {
				Item atual = this.itens [i];

				// Verifica se é o mesmo item e remove do inventário
				if (atual.titulo == item.titulo) {
					atual.gameObject.SetActive (true);

					this.itens.Remove (atual);
				}
			}
		}

		// Adiciona item clicado ao inventário
		this.itens.Add (item);
		item.gameObject.SetActive (false);
	}

}
