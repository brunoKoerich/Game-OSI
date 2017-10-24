using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class NPC : MonoBehaviour {
	
	private bool jogadorPerto = false;

	public List <Missao> missoes = new List <Missao> ();
	private bool falou = false;

	public bool getFalou() {
		return this.falou;
	}
	
	// Update is called once per frame
	private void Update () {
		if (this.jogadorPerto && Input.GetButtonUp("Jump")) {
			this.falou = true;
		}
	}

	private void OnTriggerEnter (Collider col) {
		this.ChecarJogadorPerto (col);
	}

	void OnTriggerExit (Collider col) {
		this.ChecarJogadorLonge (col);
	}

	private void ChecarJogadorPerto(Collider col) {
		if (col.gameObject.tag == "Player") {
			this.jogadorPerto = true;
		}
	}

	private void ChecarJogadorLonge(Collider col) {
		if (col.gameObject.tag == "Player") {
			this.jogadorPerto = false;
		}
	}
}
