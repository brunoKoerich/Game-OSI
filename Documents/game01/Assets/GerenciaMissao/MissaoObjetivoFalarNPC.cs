using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissaoObjetivoFalarNPC : MissaoObjetivo {

	public NPC npc;

	private void Start () {
		if (this.npc == null) {
			Debug.Log ("Objetivo \"" + this.titulo + "\" sem NPC");
		}
	}

	private void Update () {
		this.ChecarNPC ();
	}

	private void ChecarNPC () {
		if (this.npc == null) {
			return;
		}

		if (this.npc.getFalou () && !this.completo) {
			this.Completar ();
		}
	}
}
