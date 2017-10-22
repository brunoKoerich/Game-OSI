using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissaoObjetivoFalarNPC : MissaoObjetivo {

	public NPC npc;

	private void Update () {
		this.ChecarNPC ();
	}

	private void ChecarNPC () {
		if (this.npc.getFalou () && !this.completo) {
			this.Completar ();
		}
	}
}
