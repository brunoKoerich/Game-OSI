using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Item : MonoBehaviour {

	public string titulo;
	public string descricao;

	private Camera camera;
	private Inventario inventario;

	private void Start() {
		this.camera = GameObject.FindObjectOfType<Camera>();
		this.inventario = GameObject.FindObjectOfType<Inventario>();

		if (this.inventario == null) {
			Debug.Log ("Inventário não encontrado");
		}
	}

	private void Update() {
		if (this.inventario == null) {
			return;
		}

		if (Input.GetMouseButtonDown(0)){
			// Projeta um "raio" da tela até aonde o jogador clicou no jogo
			Ray ray = this.camera.ScreenPointToRay(Input.mousePosition);

			// Verifica se colidiu com algum objeto
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)){
				Debug.Log (hit.transform.gameObject.name);

				// Verifica se o objeto é um item
				Item item = hit.transform.gameObject.GetComponent<Item>();
				if (item != null) {
					this.inventario.AdicionarItem (item, true);
				}
			}
		}
	}
}
