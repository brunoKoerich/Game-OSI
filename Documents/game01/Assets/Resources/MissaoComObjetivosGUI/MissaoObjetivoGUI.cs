using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissaoObjetivoGUI : MonoBehaviour {

	public Text status;
	public Text titulo;

	private MissaoObjetivo objetivo;

	public void Update () {
		if (this.objetivo == null) {
			return;
		}

		this.AtualizaStatus ();
	}

	public void SetObjetivo(MissaoObjetivo objetivo) {
		this.objetivo = objetivo;

		this.titulo.text = objetivo.titulo;
		this.AtualizaStatus ();
	}

	private void AtualizaStatus() {
		if (this.objetivo.completo) {
			this.status.text = "ok"; 
		} else {
			this.status.text = " -";
		}
	}
}
